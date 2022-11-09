using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.Core;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Login Register Apileri bu controller'da yapılacak
        [HttpPost]
        public IActionResult Login()
        {



            return Created("", new JwtTokenGenerator().GenerateToken());
        }

    }
}
