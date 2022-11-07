using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.BLL.Repositories.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Dto.RoleDtos;
using TestStock.Dto.RolesDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class RolesManager : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesManager(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public IDataResponse<bool> Add(RolesCreateDto rolesCreateDto)
        {
            var addedRoles = new Roles
              {

                Name =rolesCreateDto.Name,

              };
            _rolesRepository.Add(addedRoles);
            return new DataResponse<bool>(true, true, "roles added");
        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletedRoles = _rolesRepository.GetByFilter(x => x.Id == id);
            if (deletedRoles==null)
            {
                return new DataResponse<bool>(false, false, "roles not found");
            }
            return new DataResponse<bool>(true, true, "role deleted");
        }

        public IDataResponse<List<RolesListDto>> GetAllRoles()
        {
            var roles=_rolesRepository.GetAll();
            if (roles==null)
            {
                return new DataResponse<List<RolesListDto>>(null, false, "roles not found");
            }
            var rolesListDto = new List<RolesListDto>();
            foreach (var role in roles)
            {
                rolesListDto.Add(new RolesListDto
                {
                    Id = role.Id,
                    Name = role.Name,

                });
             
            }
            return new DataResponse<List<RolesListDto>>(rolesListDto, true);
        }

        public IDataResponse<RolesListDto> GetRoleByFilter(Expression<Func<Roles, bool>> filter)
        {
            var roles = _rolesRepository.GetByFilter(filter);
            var rolesListDto = new RolesListDto { 
             Id = roles.Id,
             Name=roles.Name,
            };    
            return new DataResponse<RolesListDto>(rolesListDto, true);
        }

        public IDataResponse<List<RolesListDto>> GetRolesByFilter(Expression<Func<Roles, bool>> filter)
        {
            var roles = _rolesRepository.GetAllByFilter(filter);
            if (roles==null)
            {
                return new DataResponse<List<RolesListDto>>(null, false, "not found");
            }
            var rolesListDto=new List<RolesListDto>();
            foreach (var role in roles)
            {
                rolesListDto.Add(new RolesListDto
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }
            return new DataResponse<List<RolesListDto>>(rolesListDto, true);

        }

        public IDataResponse<RolesListDto> GetRolesById(int roleId)
        {
            var roles = _rolesRepository.GetByFilter(x => x.Id == roleId);
            var rolesListDto=new RolesListDto
            {
                Id= roles.Id,
                Name=roles.Name
            };
            return new DataResponse<RolesListDto>(rolesListDto, true);
        }

        public IDataResponse<bool> Update(RolesUpdateDto rolesUpdateDto)
        {
            var role=_rolesRepository.GetByFilter(x=>x.Id==rolesUpdateDto.Id);
            role.Id = rolesUpdateDto.Id;
            role.Name = rolesUpdateDto.Name;
            _rolesRepository.Update(role);
            return new DataResponse<bool>(true, true, " role updated");
        }
    }
}
