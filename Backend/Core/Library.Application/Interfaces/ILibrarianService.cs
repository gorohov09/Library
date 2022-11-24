using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<IEnumerable<OrderDetailsForReaderVm>> GetReaderOrders(string libraryCard);
    }
}
