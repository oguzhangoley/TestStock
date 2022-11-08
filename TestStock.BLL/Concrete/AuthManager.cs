using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Core.Utilities.Hashing;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;


        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResponse<bool> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = _userService.GetByEmail(userLoginDto.Email);
                if (user.Data == null)
                {
                    return new DataResponse<bool>(false, false, "email yanlıs");
                }
                var result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordHash);
                if (result)
                {
                    return new DataResponse<bool>(true, true, "passowordhashdoru");
                }
                return new DataResponse<bool>(false, false, "olmadu");
            }
            catch (Exception e)
            {

                return new DataResponse<bool>(false,false,e.Message);
            }
          
        }

        public IDataResponse<bool> Register(UserCreateDto userCreateDto)
        {
            bool result=CheckIfEmailExists(userCreateDto.Email);
            if (result)
            {
                _userService.Add(userCreateDto);
                return new DataResponse<bool>(result, true);
            }
            return new DataResponse<bool>(false, false);
        }

        private bool CheckIfEmailExists(string email)
        {
            var list=_userService.GetByEmail(email);
            if (list.Data!=null)
            {
                return false;
            }
            return true;
        }
    }
}
