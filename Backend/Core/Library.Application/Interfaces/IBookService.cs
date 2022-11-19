using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookVm>> GetAllBooks(string section);
        Task<BookDetailsVm> GetBookByISBN(string ISBN);

        Task<IEnumerable<string>> GetBookSections();
    }
}
