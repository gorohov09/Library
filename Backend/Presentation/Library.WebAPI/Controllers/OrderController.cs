using Library.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] RequestOrder requestOrder)
        {
            
        }
    }
}
