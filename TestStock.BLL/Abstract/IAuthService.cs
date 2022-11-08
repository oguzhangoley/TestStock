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
    public interface IAuthService
    {
       IDataResponse<bool> Login(UserLoginDto userLoginDto);
       IDataResponse<bool> Register(UserCreateDto userCreateDto);


    }
}
