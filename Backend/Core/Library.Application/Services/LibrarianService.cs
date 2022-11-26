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

        public async Task<IEnumerable<BriefOrderInfoForLibrarians>> GetLibrarianOrders(int librarianId)
        {
            var librariansOrders = await _orderRepository.GetLibrarianOrders(librarianId);
            var ordersVm = _mapper.Map<IEnumerable<BriefOrderInfoForLibrarians>>(librariansOrders);

            return ordersVm;
        }

        public Task<OrderDetailsForLibrarianVm> GetDetailedInfoAboutOrder(int orderId)
        {
            //var order = await _orderRepository
            return null;
        }
    }
}
