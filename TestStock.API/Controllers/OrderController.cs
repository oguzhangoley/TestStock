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

        // Order ile ilgili işlemler bu controller da olacak
        [HttpPost("Create")]
        public IActionResult Create(OrderCreateDto orderCreateDto)
        {
            var result = _orderService.Add(orderCreateDto);
            return Ok(result);
        }

        [HttpGet("GetAllList")]
        public IActionResult GetList()
        {
            var result = _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(OrderUpdateDto orderUpdateDto)
        {
            var result = _orderService.Update(orderUpdateDto);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);
            return Ok(result);
        }

    }
}
