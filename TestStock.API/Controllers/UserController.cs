using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.UserDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Kullanıcı ile ilgili işlemler bu controller da olacak
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetUsersas()
        {
            var result = _userService.GetAll();
            if (result==null)
            {
                return BadRequest("user notfound");
            }
            return Ok(result);
        }
    }
}
