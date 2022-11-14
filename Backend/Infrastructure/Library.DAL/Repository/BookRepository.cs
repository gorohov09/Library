using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<BookEntity>> GetAllBooks()
        {
            var books = await _libraryContext.BookInfos
                .Include(a => a.Authors)
                .ToListAsync();

            return books;
        }

        public async Task<BookEntity> GetBookByISBN(string ISBN)
        {
            var book = await _libraryContext
                .BookInfos
                .Include(a => a.Authors)
                .Include(i => i.BookInsatnces)
                .FirstOrDefaultAsync(x => x.ISBN == ISBN);

            return book;
        }
    }
}
