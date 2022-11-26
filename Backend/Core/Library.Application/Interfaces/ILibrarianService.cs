using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<IEnumerable<BriefOrderInfoForLibrarians>> GetLibrarianOrders(int librarianId);
    }
}
