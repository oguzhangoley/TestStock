using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Abstract
{
    public interface IAuthService
    {

        Task<string> Login(UserCreateDto userCreateDto, string returnUrl);
        Task<string> Logout();

       
    }
}
