using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.CustomerDtos;
using TestStock.Dto.UserDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getallCustomer")]
        public IActionResult GetCustomer()
        {
            var result = _customerService.GetAllCustomers();
            return Ok(result);
        }

        [HttpGet("getByIdCustomer")]
        public IActionResult GetCustomerById(int customerId)
        {
            var result=_customerService.GetCustomerById(customerId);
            return Ok(result);
         }

   

        [HttpPost("updateCustomer")]
        public IActionResult UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            var result = _customerService.Update(customerUpdateDto);
            return Ok(result);
        }

        [HttpPost("deleteCustomer")]
        public IActionResult DeleteCustomer(int customerId)
        {
            var result=_customerService.Delete(customerId);
            return Ok(result);

        }

        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            var result = _customerService.GetCustomerWithRoleName();
            return Ok(result);
        }
    }
}
