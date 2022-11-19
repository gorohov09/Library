using AutoMapper;
using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookVm>> GetAllBooks(string section)
        {
            var books = section == "all" ? await _bookRepository.GetAllBooks() : await _bookRepository.GetBooksBySection(section);

            var booksVm = books.Select(book => _mapper.Map<BookVm>(book));

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

            var bookVm = _mapper.Map<BookVm>(book);

            return bookVm;
        }

        public async Task<IEnumerable<string>> GetBookSections()
        {
            return await _bookRepository.GetBookSections();
        }
    }
}
