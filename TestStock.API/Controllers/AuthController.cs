using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestStock.BLL.Abstract;
using TestStock.Core;
using TestStock.Dto.AuthDtos;

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

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _authService.Login(loginDto);
            if(result.Status == false)
            {
                return NotFound();
            }
            return Created("", new JwtTokenGenerator().GenerateToken());
        }

      
    }
}
