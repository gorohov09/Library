using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using AutoMapper;

namespace Library.Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IRecordRepository _recordRepository;
        private IMapper _mapper;

        public LibrarianService(IOrderRepository orderRepository, IReaderRepository readerRepository, IRecordRepository recordRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _readerRepository = readerRepository;
            _recordRepository = recordRepository; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailsForLibrarianVm>> GetLibrarianOrders(int librarianId)
        {
            var librariansOrders = await _orderRepository.GetLibrarianOrders(librarianId);
            var ordersVm = _mapper.Map<IEnumerable<OrderDetailsForLibrarianVm>>(librariansOrders);
            foreach (var order in ordersVm)
            {
                var readerHistory = await _recordRepository.GetReadersHistory(order.Reader.LibraryCard);
                order.Reader.History = _mapper.Map<IEnumerable<RecordDetailsForReaderVm>>(readerHistory);
            }

            return ordersVm;
        }
    }
}
