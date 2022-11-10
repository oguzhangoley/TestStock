using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestStock.BLL.Abstract;
using TestStock.Dto.CustomerDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
      private readonly IAuthService _authService;
        private readonly ICustomerService _customerService;
        public AuthController(IAuthService authService, ICustomerService customerService)
        {
            _authService = authService;
            _customerService = customerService;
        }



        [HttpPost("login")]
        public IActionResult Login(CustomerSignInDto customerSignInDto)
        {
            var result = _authService.Login(customerSignInDto);
            return Ok(result);
        }


        [HttpPost("register")]
        public IActionResult AddCustomer(CustomerCreateDto customerCreateDto)
        {
            var result = _customerService.Add(customerCreateDto);
            return Ok(result);
        }
    }
}
