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
        private IMapper _mapper;

        public LibrarianService(IOrderRepository orderRepository, IReaderRepository readerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailsForLibrarianVm>> GetLibrarianOrders(int librarianId)
        {
            var librariansOrders = await _orderRepository.GetLibrarianOrders(librarianId);
            return _mapper.Map<IEnumerable<OrderDetailsForLibrarianVm>>(librariansOrders);
        }
    }
}
