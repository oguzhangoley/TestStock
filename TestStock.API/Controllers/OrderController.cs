using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.OrderDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(OrderCreateDto dto)
        {
            var result = _orderService.AddOrder(dto); //
            return Ok(result);
        }

        [HttpGet("GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var result = _orderService.GetOrderById(id);
            return Ok(result);    
        }

        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            var result = _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpPost("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _orderService.DeleteOrder(id);
            return Ok(result);
        }
    }
}
