using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Core.Utilities.Security.Jwt;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Abstract
{
    public interface IAuthService
    {
       IDataResponse<User> Login(UserLoginDto userLoginDto);
       IDataResponse<User> Register(UserCreateDto userCreateDto);
       IDataResponse<AccessToken> CreateAccessToken(User user);


    }
}
