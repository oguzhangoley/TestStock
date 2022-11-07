using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.PorductDtos;
using TestStock.Dto.RolesDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet("rolesGetAll")]
        public IActionResult GetAllProducts()
        {
            var result = _rolesService.GetAllRoles();
            return Ok(result);
        }

        [HttpGet("Roles getById ")]
        public IActionResult GetActionById(int roleId)
        {
            var result = _rolesService.GetRolesById(roleId);
            return Ok(result);
        }


        [HttpPost("addRole")]
        public IActionResult AddProduct(RolesCreateDto dto)
        {
            var result = _rolesService.Add(dto);
            return Ok(result);


        }

        [HttpPost("updateRole")]
        public IActionResult UpdateProduct(RolesUpdateDto dto)
        {
            var reuslt = _rolesService.Update(dto);
            return Ok(reuslt);
        }

        [HttpPost("deleteRole")]
        public IActionResult DeleterOLE(int roleId)
        {
            var result = _rolesService.Delete(roleId);
            return Ok(result);
        }
    }
}
