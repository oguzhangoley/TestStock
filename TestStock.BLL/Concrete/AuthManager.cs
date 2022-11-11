using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.AuthDtos;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthManager(IUserRepository userRepository)
        {
                _userRepository = userRepository;   
        }

        public IDataResponse<bool> Login(LoginDto loginDto)
        {
            var result = _userRepository.GetByFilter(x => x.Email == loginDto.Email);
            if(result==null)
            {
                return new DataResponse<bool>(false,false,"Kullanıcı bulunamadı");
            }
            if (result.Password == loginDto.Password)
            {
                return new DataResponse<bool>(true, true, "Giriş yapıldı");
            }
            return new DataResponse<bool>(false, false, "Şifre Yasnlış");
        }

        public IDataResponse<bool> Register(UserCreateDto userCreateDto)
        {
           if(userCreateDto == null)
            {
                return new DataResponse<bool>(false, false, "kullanıcı boş olamaz");

            }
            var user = new User
            {
                UserName = userCreateDto.UserName,
                Password = userCreateDto.password,
                Email = userCreateDto.email
            };
            _userRepository.Add(user);
            return new DataResponse<bool>(true, true, "İşlem başarılı");
        }
    }
}
