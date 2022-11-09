using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.UserDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Login Register Apileri bu controller'da yapılacak
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateDto userCreateDto)
        {
            var result=_authService.Register(userCreateDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var result = _authService.Login(userLoginDto);
            if (result.Status == false)
            {
                return BadRequest();
            }
            var token = _authService.CreateAccessToken(result.Data);
            if (token.Data == null)
            {
                return BadRequest();
            }
            return Ok(token);


        }
    }
}
