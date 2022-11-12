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

        [HttpGet("all")] //http://localhost:5162/api/books/all
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{ISBN}")]
        public async Task<IActionResult> GetBook(string ISBN)
        {
            var book = await _bookService.GetBookByISBN(ISBN);

            return book != null ? Ok(book) : NotFound();
        }
    }
}
