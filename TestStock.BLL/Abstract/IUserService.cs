using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface IUserService
    {
        IDataResponse<bool> Add(UserCreateDto userCreateDto);
        IDataResponse<bool> Update(UserUpdateDto userUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<UserListDto>> GetAllUser();
        IDataResponse<List<UserListDto>> GetUsersByFilter(Expression<Func<Users, bool>> filter);
        IDataResponse<UserListDto> GetUserById(int userId);
        IDataResponse<UserListDto> GetUserByFilter(Expression<Func<Users, bool>> filter);
    }
}
