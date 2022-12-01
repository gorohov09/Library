using AutoMapper;
using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
using Library.Application.Vm;
using Library.DAL.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IReaderRepository _readerRepository;

        private readonly IBookRepository _bookRepository;

        private readonly ILibrarianRepository _librarianRepository;

        private readonly IOrderRepository _orderRepository;

        private readonly IRecordRepository _recordRepository;

        private readonly IMapper _mapper;

        public OrderService(IReaderRepository readerRepository, IBookRepository bookRepository,
            ILibrarianRepository librarianRepository, IOrderRepository orderRepository, IMapper mapper,
            IRecordRepository recordRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _librarianRepository = librarianRepository;
            _orderRepository = orderRepository;
            _recordRepository = recordRepository;
            _mapper = mapper;
        }

        public async Task<ResponseApproveOrder> ApproveOrder(RequestApproveOrder requestApproveOrder)
        {
            if (requestApproveOrder == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Неизвестная ошибка" };

            var orderEntity = await _orderRepository.GetOrderById(requestApproveOrder.OrderId);

            if (orderEntity == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Данной заявки нет" };

            if (orderEntity.BookInsatnce == null || orderEntity.Reader == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Отсутствует читатель или книга" };

            var librarianEntity = await _librarianRepository.GetLibrarianById(requestApproveOrder.LibrarianId);

            if (librarianEntity == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Читатель отсутствует в библиотеке" };

            //Допилить, если библио что-то сделал, то заявку завязать на него
            if (requestApproveOrder.IsApproved)
            {
                //Обработать корректность отправленной даты

                var recordEntity = new RecordEntity
                {
                    Reader = orderEntity.Reader,
                    BookInsatnce = orderEntity.BookInsatnce,
                    IssueDate = DateTime.Now,
                };

                var result = await _recordRepository.SaveRecord(recordEntity);

                if (result)
                {
                    orderEntity.Status = StatusOrder.DONE;
                    orderEntity.ExecutionDate = DateTime.Now;
                    orderEntity.Librarian = librarianEntity;

                    var resultUpdate = await _orderRepository.UpdateOrder(orderEntity);

                    if (resultUpdate)
                        return new ResponseApproveOrder { IsSuccess = true };
                }
            }
            else
            {
                orderEntity.BookInsatnce.IsAvailable = true;
                orderEntity.Status = StatusOrder.DENIED;
                orderEntity.ExecutionDate = DateTime.Now;
                orderEntity.Librarian = librarianEntity;

                var resultUpdate = await _orderRepository.UpdateOrder(orderEntity);

                if (resultUpdate)
                    return new ResponseApproveOrder { IsSuccess = true};
            }

            return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Ошибка при сохранении данных" };
        }

        public async Task<ResponseOrder> CreateOrder(RequestOrder requestOrder)
        {
            if (requestOrder == null)
                return new ResponseOrder { IsSuccess = false, ErrorMessage = "Неизвестная ошибка" };

            var readerEntity = await _readerRepository.GetReaderByLibraryCard(requestOrder.LibraryCard);

            //Если читатель не найден, то заявка не может быть оформлена
            if (readerEntity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Пользователь с номером чит. билета {requestOrder.LibraryCard} не найден"
                };

            BookInsatnceEntity bookInstanceEnity;

            if (!string.IsNullOrEmpty(requestOrder.BookISBN))
                bookInstanceEnity = await _bookRepository.GetFirstInsatnceBook(requestOrder.BookISBN);
            else
            {
                var historyEntity = await _recordRepository.GetRecordById(requestOrder.HistoryId);
                bookInstanceEnity = await _bookRepository.GetInsatnceBookById(historyEntity.BookId);
            }
                

            //Если экземпляра книги не существует в библиотеке, то заявка не может быть оформлена
            if (bookInstanceEnity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Экземпляр книги с ISBN {requestOrder.BookISBN} не найден"
                };

            if (!string.IsNullOrEmpty(requestOrder.BookISBN))
                //Делаем экземпляр книги недоступным
                bookInstanceEnity.IsAvailable = false;

            //Формирование объекта - заявка
            var orderEntity = new OrderEntity
            {
                BookInsatnce = bookInstanceEnity,
                Reader = readerEntity,
                CreationDate = DateTime.Now,
                Status = StatusOrder.WAIT,
                Type = !string.IsNullOrEmpty(requestOrder.BookISBN) ? TypeOrder.ISSUE : TypeOrder.RETURN
            };

            orderEntity = await _orderRepository.SaveOrder(orderEntity);

            if (orderEntity.Id <= 0)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Не удалось сохранить данные"
                };

            return new ResponseOrder { IsSuccess = true };
        }

        public async Task<OrderDetailsForLibrarianVm> GetOrderDetails(int orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            var orderVm = _mapper.Map<OrderDetailsForLibrarianVm>(order);
            
            var historyEntity = await _recordRepository.GetReadersHistory(orderVm.Reader.LibraryCard);
            orderVm.Reader.History = _mapper.Map<IEnumerable<RecordDetailsForReaderVm>>(historyEntity);
            
            return orderVm;
        }

        public async Task<ResponseApproveOrder> ReturnApproveOrder(RequestApproveOrder returnApproveOrder)
        {
            if (returnApproveOrder == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Неизвестаня ошибка" };

            var order = await _orderRepository.GetOrderById(returnApproveOrder.OrderId);

            if (order == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Заявка не может быть найдена" };

            var bookInstance = await _bookRepository.GetInsatnceBookById(order.BookInsatnceId);

            if (bookInstance == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Экземпляр книги не может быть найден" };

            bookInstance.IsAvailable = true;

            //Додумать дальше логику
            //Отфильтровать все записи истории по BookInstanceId и взять где ReturnDate == null
            var historyEntity = await _recordRepository.GetFreeRecord(bookInstance.Id);

            if (historyEntity == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Запись не может быть найдена" };

            historyEntity.ReturnDate = DateTime.Now;

            var librarianEntity = await _librarianRepository.GetLibrarianById(returnApproveOrder.LibrarianId);

            if (librarianEntity == null)
                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Читатель отсутствует в библиотеке" };

            order.Librarian = librarianEntity;
            order.ExecutionDate = DateTime.Now; 

            var result = await _orderRepository.UpdateOrder(order);
            if (result)
                return new ResponseApproveOrder { IsSuccess = true };

            return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Неизвестная ошибка" }; ;
        }
    }
}
