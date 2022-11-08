using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.CustomerDtos;

namespace TestStock.BLL.Abstract
{
    public interface IAuthService
    {
        IDataResponse<string> Login(CustomerSignInDto customerSignInDto);
    }
}
