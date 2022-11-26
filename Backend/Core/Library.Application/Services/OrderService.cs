using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
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

        public OrderService(IReaderRepository readerRepository, IBookRepository bookRepository,
            ILibrarianRepository librarianRepository, IOrderRepository orderRepository, IRecordRepository recordRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _librarianRepository = librarianRepository;
            _orderRepository = orderRepository;
            _recordRepository = recordRepository;
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

            if (requestApproveOrder.IsApproved)
            {
                //Обработать корректность отправленной даты

                var recordEntity = new RecordEntity
                {
                    Reader = orderEntity.Reader,
                    BookInsatnce = orderEntity.BookInsatnce,
                    IssueDate = DateTime.Now,
                    ReturnDate = requestApproveOrder.ReturnDate,
                };

                var result = await _recordRepository.SaveRecord(recordEntity);

                if (result)
                {
                    orderEntity.Status = StatusOrder.DONE;
                    orderEntity.ExecutionDate = DateTime.Now;

                    return new ResponseApproveOrder { IsSuccess = true };
                }

                return new ResponseApproveOrder { IsSuccess = false, ErrorMessage = "Ошибка при сохранении данных" };
            }
            else
            {
                orderEntity.BookInsatnce.IsAvailable = true;
                orderEntity.Status = StatusOrder.DENIED;
                orderEntity.ExecutionDate = DateTime.Now;

                //Обновить данные

                return new ResponseApproveOrder { IsSuccess = true};
            }
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

            var bookInstanceEnity = await _bookRepository.GetFirstInsatnceBook(requestOrder.BookISBN);

            //Если экземпляра книги не существует в библиотеке, то заявка не может быть оформлена
            if (bookInstanceEnity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Экземпляр книги с ISBN {requestOrder.BookISBN} не найден"
                };

            //Если библиотекаря нет - заявка не может быть сформирована
            var librarianEntity = await _librarianRepository.GetFirstLibrarian();
            if (librarianEntity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = "Библиотекарей нет"
                };

            //Формирование объекта - заявка 
            var orderEntity = new OrderEntity
            {
                BookInsatnce = bookInstanceEnity,
                Librarian = librarianEntity,
                Reader = readerEntity,
                CreationDate = DateTime.Now,
                Status = StatusOrder.WAIT
            };

            //Делаем экземпляр книги недоступным
            bookInstanceEnity.IsAvailable = false;
            orderEntity = await _orderRepository.SaveOrder(orderEntity);

            if (orderEntity.Id <= 0)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Не удалось сохранить данные"
                };

            return new ResponseOrder { IsSuccess = true };
        }
    }
}
