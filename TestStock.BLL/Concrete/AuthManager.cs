using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        public Task<string> Login(UserCreateDto userCreateDto, string returnUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
