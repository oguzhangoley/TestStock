using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Core.Utilities.Hashing;
using TestStock.Core.Utilities.Security.Jwt;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private  IUserService _userService;
        ITokenHelper _tokenHelper;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResponse<AccessToken> CreateAccessToken(User user)
        {
           var claims = _userService.GetClaims(user);
           var accessToken= _tokenHelper.CreateToken(user, claims);
            return new DataResponse<AccessToken>(accessToken,true);
        }

        public IDataResponse<User> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = _userService.GetByEmail(userLoginDto.Email);
                if (user.Data == null)
                {
                    return new DataResponse<User>(null, false, "email yanlıs");
                }
                var result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt);
                if (!result)
                {
                    return new DataResponse<User>(null, false, "passwod yanlis");
                }
                return new DataResponse<User>(user.Data,true, "hg");
            }
            catch (Exception e)
            {

                return new DataResponse<User>(null,false,e.Message);
            }
          
        }

        public IDataResponse<User> Register(UserCreateDto userCreateDto)
        {
            bool result=CheckIfEmailExists(userCreateDto.Email);
            if (result)
            {
                _userService.Add(userCreateDto);
                return new DataResponse<User>(null, true);
            }
            return new DataResponse<User>(null, false);
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
