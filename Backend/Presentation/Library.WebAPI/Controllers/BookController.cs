using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Метод получения книг(Или всех или только по конкретной секции)
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpGet()] //http://localhost:5162/api/books?section=название_секции
        public async Task<IActionResult> GetBooks([FromQuery]string section)
        {
            //Если section = all, то возвращаем все книги
            //Если что-то другое, напромер Математика или Физика, то возвращаем книги конкретно данной секции
            var books = await _bookService.GetAllBooks(section);
            return Ok(books);
        }

        [HttpGet("{ISBN}")]
        public async Task<IActionResult> GetBook(string ISBN)
        {
            var book = await _bookService.GetBookByISBN(ISBN);

            return book != null ? Ok(book) : NotFound();
        }

        [HttpGet("sections/all")]
        public async Task<IActionResult> GetSections()
        {
            return Ok(new
            {
                sections = await _bookService.GetBookSections()
            });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBook([FromQuery] string template)
        {
            return Ok(new
            {
                books = await _bookService.SearchBookByName(template)
            });
        }
    }
}
