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
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        

        [HttpPost("login")]
        public IActionResult Login(CustomerSignInDto customerSignInDto)
        {
            var result = _authService.Login(customerSignInDto);
            return Ok(result);
        }
    }
}
