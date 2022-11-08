using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TestStock.BLL.Abstract;
using TestStock.Dto.CategoryDtos;
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

        [HttpGet("Orders")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("Order")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrdertById(id);
            return Ok(order);
        }

        [HttpPost("adedOrder")]
        public IActionResult Add(OrderCreateDto orderCreateDto)
        {
            var order = _orderService.Add(orderCreateDto);  
            return Ok(order);
        }

        [HttpPost("updateOrder")]
        public IActionResult Update(OrderUpdateDto orderUpdateDto)
        {
            var order = _orderService.Update(orderUpdateDto);
            return Ok(order);
        }


        [HttpPost("deleteOrder")]
        public IActionResult Delete(int id)
        {
            var order = _orderService.Delete(id);
            return Ok(order);
        }

    }
}
