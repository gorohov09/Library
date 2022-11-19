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

            var booksVm = _mapper.Map<IEnumerable<BookVm>>(books);

            //Бизнес-логика

            return booksVm;
        }

        public async Task<BookDetailsVm> GetBookByISBN(string ISBN)
        {
            var book = await _bookRepository.GetBookByISBN(ISBN);

            if (book == null)
            {
                return null;
            }

            var bookDetailsVm = _mapper.Map<BookDetailsVm>(book);
            bookDetailsVm.Count = await _bookRepository.InstancesCount(book);

            return bookDetailsVm;
        }

        public async Task<IEnumerable<string>> GetBookSections()
        {
            return await _bookRepository.GetBookSections();
        }
    }
}
