using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookVm>> GetAllBooks();
        Task<BookVm> GetBookById(int id);
    }
}
