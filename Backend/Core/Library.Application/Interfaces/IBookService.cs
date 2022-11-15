using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookVm>> GetAllBooks();
        Task<BookVm> GetBookByISBN(string ISBN);

        Task<IEnumerable<string>> GetBookSections();
    }
}
