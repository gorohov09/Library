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

        public async Task<IEnumerable<BookEntity>> GetBooksBySection(string section)
        {
            var books = await _libraryContext.BookInfos
                .Where(a => a.Section == section)
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

        public async Task<IEnumerable<string>> GetBookSections()
        {
            return _libraryContext.BookInfos
                .Select(a => a.Section)
                .Distinct();
        }

        public async Task<int> InstancesCount(BookEntity book)
        {
            return _libraryContext.BookIntances
                .Where(a => a.ISBN == book.ISBN && a.IsAvailable)
                .Count();
        }

        public async Task<BookInsatnceEntity> GetFirstInsatnceBook(string ISBN)
        {
            return await _libraryContext.BookIntances
                .FirstOrDefaultAsync(b => b.ISBN == ISBN && b.IsAvailable);
        }

        public async Task<IEnumerable<BookEntity>> GetBooksByName(string tempalte)
        {
            return _libraryContext.BookInfos
                .Where(x => x.Title.Contains(tempalte))
                .Include(x => x.Authors)
                .ToList();
        }

        public async Task<BookInsatnceEntity> GetInsatnceBookById(int id)
        {
            return await _libraryContext.BookIntances
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
