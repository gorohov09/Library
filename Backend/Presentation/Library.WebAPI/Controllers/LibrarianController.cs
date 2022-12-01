using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Interfaces;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _librarianService;

        public LibrarianController(ILibrarianService librarianService)
        {
            _librarianService = librarianService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders([FromQuery] string typeOrders)
        {
            return Ok(new
            {
                orders = await _librarianService.GetLibrarianOrders(typeOrders)
            }) ;
        }
    }
}
