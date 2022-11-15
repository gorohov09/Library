using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookByISBN(string ISBN);

        Task<IEnumerable<string>> GetBookSections();
    }
}
