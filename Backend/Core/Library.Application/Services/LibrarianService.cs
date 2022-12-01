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
        private readonly IConverter _converter;
        private IMapper _mapper;

        public LibrarianService(IOrderRepository orderRepository, IReaderRepository readerRepository, 
            IRecordRepository recordRepository, IMapper mapper, IConverter converter)
        {
            _orderRepository = orderRepository;
            _readerRepository = readerRepository;
            _recordRepository = recordRepository; 
            _mapper = mapper;
            _converter = converter;
        }

        public async Task<IEnumerable<BriefOrderInfoForLibrarians>> GetLibrarianOrders(string typeOrders)
        {
            IEnumerable<OrderEntity> listOrdersEntity;

            if (typeOrders == "return")
                listOrdersEntity = await _orderRepository.GetLibrarianOrders(TypeOrder.RETURN);
            else if (typeOrders == "recieve")
                listOrdersEntity = await _orderRepository.GetLibrarianOrders(TypeOrder.ISSUE);
            else
                return null;

            var ordersVm = _mapper.Map<IEnumerable<BriefOrderInfoForLibrarians>>(listOrdersEntity);

            foreach (var order in listOrdersEntity.Zip(ordersVm, (e,v) => new {Entity = e, Vm = v}))
            {
                order.Vm.BookAuthors = _converter.GetAuthorsInLine(order.Entity.BookInsatnce.BookInfo);
            }

            return ordersVm;
        }
    }
}
