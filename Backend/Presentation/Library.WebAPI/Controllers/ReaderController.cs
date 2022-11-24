using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Interfaces;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet("{libraryCard}")]
        public async Task<IActionResult> GetUserInfo([FromBody] string libraryCard)
        {
            return Ok(_readerService.GetReaderInfo(libraryCard));
        }

        [HttpGet("{libraryCard}/orders")]
        public async Task<IActionResult> GetUserOrders([FromBody] string libraryCard)
        {
            return Ok();
        }
    }
}
