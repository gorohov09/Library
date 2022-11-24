using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using AutoMapper;

namespace Library.Application.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRecordRepository _recordRepository;
        private readonly IReaderRepository _readerRepository;
        private IMapper _mapper;

        public ReaderService(IOrderRepository orderRepository, IRecordRepository recordRepository, IReaderRepository readerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _recordRepository = recordRepository;
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public async Task<ReaderVm> GetReaderInfo(string libraryCard)
        {
            var reader = await _readerRepository.GetReaderByLibraryCard(libraryCard);
            if (reader == null)
            {
                return null;
            }

            var readerInfoVm = _mapper.Map<ReaderVm>(reader);
            readerInfoVm.History = await _recordRepository.GetReadersHistory(libraryCard);
            readerInfoVm.Orders = await _orderRepository.GetReaderOrders(libraryCard);

            return readerInfoVm;
        }
    }
}
