using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.AuthDtos;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.UserDtos;

namespace TestStock.BLL.Abstract
{
    public interface IAuthService
    {

        //DataResponse<List<UserListDto>> GetAllLogin(UserListDto dto,string returnUrl);
        //Task<DataResponse> Login(UserListDto userlistDto, string returnUrl);

        //public async Task<IResponse<UserListDto>> RegisterAsync(UserCreateDto dto);
        //DataResponse<UserListDto> Register(string username,string password,string returnUrl);   
        IDataResponse<bool> Login(LoginDto loginDto);
        IDataResponse<bool> Register(UserCreateDto userCreateDto);   

    }
}
