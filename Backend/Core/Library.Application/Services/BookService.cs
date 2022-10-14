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

        public async Task<IEnumerable<BookVm>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();

            var booksVm = books.Select(book => new BookVm
            {
                Id = book.Id,
                Description = book.Description,
                Title = book.Title,
                CountExamplesAmount = book.CountExamplesAmount,
            });

            //Бизнес-логика

            return booksVm;
        }

        public async Task<BookVm> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                return null;
            }

            var bookVm = new BookVm
            {
                Id = book.Id,
                Description = book.Description,
                Title = book.Title,
                CountExamplesAmount = book.CountExamplesAmount,
            };

            return bookVm;
        }
    }
}
