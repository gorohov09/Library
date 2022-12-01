using Library.Application.Interfaces;
using Library.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] RequestOrder requestOrder)
        {
            var response = await _orderService.CreateOrder(requestOrder);
            return Ok(response);    
        }
        
        [HttpGet("/info/{orderId}")]
        public async Task<IActionResult> GetOrderInfo(int orderId)
        {
            return Ok(new
            {
                order = await _orderService.GetOrderDetails(orderId)
            });
        }

        [HttpPost("approve")]
        public async Task<IActionResult> ApproveOrder([FromBody] RequestApproveOrder requestApproveOrder)
        {
            var response = await _orderService.ApproveOrder(requestApproveOrder);
            return Ok(response);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnApproveOrder([FromBody] RequestApproveOrder requestRtApprvOrder)
        {
            var response = await _orderService.ReturnApproveOrder(requestRtApprvOrder);
            return Ok(response);
        }
    }
}
