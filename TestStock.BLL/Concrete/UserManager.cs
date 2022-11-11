using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.BLL.Repositories.Concrete;
using TestStock.Core.Entity.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
           _userRepository = userRepository;    
        }
        public IDataResponse<bool> Add(UserCreateDto userCreateDto)
        {
            var adedUser = new User
            {
            
                UserName = userCreateDto.UserName,
              
                Email= userCreateDto.email,
                Password=userCreateDto.password,
            };
            _userRepository.Add(adedUser);
            return new DataResponse<bool>(true, true, "adedUser");

        }

        public IDataResponse<bool> Delete(int id)
        {
            var delete = _userRepository.Delete(id);

            return new DataResponse<bool>(true, true, "delete");
           

        }

        public IDataResponse<List<UserListDto>> GetAllUser()
        {
            var list = _userRepository.GetAllUser();
            if (list == null)
            {
                return new DataResponse<List<UserListDto>>(null, false, "user found");
            }
            foreach (var user in list)
            {
                return new DataResponse<List<UserListDto>>(null, false, "user not found");

            }
            var userListDto = new List<UserListDto>();
            foreach (var user in list)
            {
                userListDto.Add(new UserListDto
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email, 
                    password=user.Password,
                   

                });

            }
            return new DataResponse<List<UserListDto>>(userListDto, true);

        }

        public IDataResponse<UserListDto> GetUserByFilter(Expression<Func<User, bool>> filter)
        {
            var user = _userRepository.GetByFilter(filter);
            var userListDto = new UserListDto
            {
                UserId = user.UserId,
              UserName=user.UserName,
                Email=user.Email,   

            };
            return new DataResponse<UserListDto>(userListDto, true);
        }

        public IDataResponse<UserListDto> GetUserById(int userId)
        {
            var user = _userRepository.GetByFilter(x => x.UserId == userId);
            var userListDto = new UserListDto
            {
                UserId = user.UserId,
                UserName = user.UserName
                
            };
            return new DataResponse<UserListDto>(userListDto, true);
        }



        public IDataResponse<bool> Update(UserUpdateDto userUpdateDto)
        {
           var user = _userRepository.GetByFilter(x => x.UserId == userUpdateDto.UserId);
            user.UserName = userUpdateDto.UserName;
            _userRepository.Update(user);
            return new DataResponse<bool>(true, true, " User update");                                                                                
        }
    }
}
