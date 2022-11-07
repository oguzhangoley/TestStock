using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Core.Response;
using TestStock.DAL.Context;
using TestStock.Dto.CustomerDtos;

namespace TestStock.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private ProjectDbContext _context;
        public AuthManager(ProjectDbContext context)
        {
            _context = context;
        }
        public IDataResponse<CustomerSignInDto> Login(string mail, string password)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Email == mail && x.Password == password);
            var customerSigninDto = new CustomerSignInDto();
            if (customer !=null)
            {
                customerSigninDto = new CustomerSignInDto
                {
                    Mail = mail,
                    Password = password
                };
                return new DataResponse<CustomerSignInDto>(customerSigninDto, true, "giriş başarılı");
            }
            return new DataResponse<CustomerSignInDto>(customerSigninDto, false, "username or password incorrect");
        }
    }
}
