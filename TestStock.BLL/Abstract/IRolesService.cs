using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.RoleDtos;
using TestStock.Dto.RolesDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface IRolesService
    {
        IDataResponse<bool> Add(RolesCreateDto rolesCreateDto);
        IDataResponse<bool> Update(RolesUpdateDto rolesUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<RolesListDto>> GetAllRoles();
        IDataResponse<List<RolesListDto>> GetRolesByFilter(Expression<Func<Roles, bool>> filter);
        IDataResponse<RolesListDto> GetRolesById(int roleId);   
        IDataResponse<RolesListDto> GetRoleByFilter(Expression<Func<Roles, bool>> filter);
    }
}
