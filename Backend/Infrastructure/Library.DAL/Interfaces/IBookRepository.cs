using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookEntity>> GetAllBooks();

        Task<IEnumerable<BookEntity>> GetBooksBySection(string section);

        Task<BookEntity> GetBookByISBN(string ISBN);

        Task<IEnumerable<string>> GetBookSections();

        Task<int> InstancesCount(BookEntity book);
    }
}
