using Library.Application.Interfaces;
using Library.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("registrate")]
        public async Task<IActionResult> Registrate([FromBody]RequestRegistrate request)
        {
            var result = await _accountService.Registrate(request);
            return Ok(result);
        }

        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn([FromBody] RequestLogin request)
        {
            var result = await _accountService.Login(request);
            return Ok(result);
        }
    }
}
