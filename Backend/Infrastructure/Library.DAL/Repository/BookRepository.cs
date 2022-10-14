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
            var books = await _libraryContext.Books.ToListAsync();

            return books;
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }
    }
}
