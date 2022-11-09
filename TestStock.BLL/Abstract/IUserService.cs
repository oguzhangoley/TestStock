using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Abstract
{
    public interface IUserService
    {
        IDataResponse<User> Add(UserCreateDto userCreateDto);
        IDataResponse<User> GetByEmail(string email);
        IDataResponse<List<UserListDto>> GetAll();
        List<Role> GetClaims(User user);
        IDataResponse<UserOrderDto> GetByIdOrders(int id);


    }
}
