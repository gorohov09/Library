using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<IEnumerable<OrderDetailsForLibrarianVm>> GetLibrarianOrders(int librarianId);
    }
}
