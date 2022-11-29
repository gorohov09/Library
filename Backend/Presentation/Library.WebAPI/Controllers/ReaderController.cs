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
        public async Task<IActionResult> GetUserInfo(string libraryCard)
        {
            return Ok(new
            {
                reader = await _readerService.GetReaderInfo(libraryCard)
            });
        }

        [HttpGet("{libraryCard}/orders")]
        public async Task<IActionResult> GetUserOrders(string libraryCard)
        {
            return Ok(new
            {
                orders = await _readerService.GetReaderOrders(libraryCard) 
            });
        }
        
        [HttpGet("search/bycard")]
        public async Task<IActionResult> SearchReadersByCard([FromQuery]string template)
        {
            return Ok(new
            {
                readers = await _readerService.SearchReaders(template, true) 
            });
        }
        
        [HttpGet("search/byname")]
        public async Task<IActionResult> SearchReadersByName([FromQuery]string template)
        {
            return Ok(new
            {
                readers = await _readerService.SearchReaders(template, false) 
            });
        }
    }
}
