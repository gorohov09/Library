using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
