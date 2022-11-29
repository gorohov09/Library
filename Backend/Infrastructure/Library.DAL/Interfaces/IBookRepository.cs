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

        Task<BookInsatnceEntity> GetFirstInsatnceBook(string ISBN);

        Task<IEnumerable<BookEntity>> GetBooksByName(string tempalte);

        Task<BookInsatnceEntity> GetBookInsatnceById(int id);
    }
}
