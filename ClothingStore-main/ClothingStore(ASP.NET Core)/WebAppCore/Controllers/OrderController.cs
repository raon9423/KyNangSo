using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.ModelViews;
using static WebAppCore.Services.OrderService;

namespace WebAppCore.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(
            IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("place_order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderViewModel orderViewModel)
        {
            try
            {
                return Ok(orderViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Đã xảy ra lỗi khi đặt hàng: {ex.Message}");
            }
        }
    }
}