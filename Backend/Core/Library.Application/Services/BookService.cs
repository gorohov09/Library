using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookVm>> GetAllBooks(string section)
        {
            var books = section == "all" ? await _bookRepository.GetAllBooks() : await _bookRepository.GetBooksBySection(section);

            var booksVm = books.Select(book => new BookVm
            {
                ISBN = book.ISBN,
                Description = book.Description,
                Title = book.Title,
                Year = book.Year,
                Section = book.Section,
                Publisher = book.Publisher,
                Authors = book.Authors.Select(author => new AuthorVm
                {
                    Id = author.Id,
                    FullName = author.FullName,
                    Country = author.Country,
                    BirthDate = author.BirthDate,
                }),
            });

            //Бизнес-логика

            return booksVm;
        }

        public async Task<BookVm> GetBookByISBN(string ISBN)
        {
            var book = await _bookRepository.GetBookByISBN(ISBN);

            if (book == null)
            {
                return null;
            }

            var bookVm = new BookVm
            {
                ISBN = book.ISBN,
                Description = book.Description,
                Title = book.Title,
                Year = book.Year,
                Section = book.Section,
                Publisher = book.Publisher,
                Authors = book.Authors.Select(author => new AuthorVm
                {
                    Id = author.Id,
                    FullName = author.FullName,
                    Country = author.Country,
                    BirthDate = author.BirthDate,
                }),
                BookInsatnces = book.BookInsatnces.Select(insatnce => new BookInsatnceVm
                {
                    Id = insatnce.Id,
                    RowNumber = insatnce.RowNumber,
                    IsAvailable = insatnce.IsAvailable,
                })
            };

            return bookVm;
        }

        public async Task<IEnumerable<string>> GetBookSections()
        {
            return await _bookRepository.GetBookSections();
        }
    }
}
