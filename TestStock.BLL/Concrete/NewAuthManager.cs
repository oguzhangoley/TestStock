using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Core.Response;
using TestStock.Core.Security;
using TestStock.Dto.CustomerDtos;

namespace TestStock.BLL.Concrete
{
    public class NewAuthManager : IAuthService
    {
        private readonly ICustomerService _customerService;

        public NewAuthManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        

        public IDataResponse<string> Login(CustomerSignInDto customerSignInDto)
        {
            var customer = _customerService.GetCustomerByMail(customerSignInDto.Mail);
            if(customer.Status == false)
            {
                return new DataResponse<string>(null, false, "böyle bir mail bulunamadı");
            }
            if(customer.Data.Password != customerSignInDto.Password)
            {
                return new DataResponse<string>(null, false, "şifre yanlış");
            }
            var token = new JwtTokenGenerator().GenerateToken();
            return new DataResponse<string>(token, true, "giriş yapıldı"); 
        }
    }
}
