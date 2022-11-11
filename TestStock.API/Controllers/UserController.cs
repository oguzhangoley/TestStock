using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.CategoryDtos;
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

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetAllUser();
            return Ok(result);
        }

        [HttpGet("user")]
        public IActionResult GetUserById(int UserId)
        {
            var result = _userService.GetUserById(UserId);
            return Ok(result);
        }

        [HttpPost("adduser")]
        public IActionResult AddUser(UserCreateDto userCreateDto)
        {
            var result = _userService.Add(userCreateDto);
            return Ok(result);
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            var result = _userService.Update(userUpdateDto);
            return Ok(result);
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userService.Delete(userId);
            return Ok(result);
        }
    }
}
