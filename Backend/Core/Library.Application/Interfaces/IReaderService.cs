using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface IReaderService
    {
        Task<ReaderVm> GetReaderInfo(string libraryCard);

        Task<IEnumerable<OrderDetailsForReaderVm>> GetReaderOrders (string libraryCard);
    }
}
