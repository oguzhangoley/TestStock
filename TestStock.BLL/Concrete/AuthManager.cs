using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.Core.Response;
using TestStock.DAL.Context;
using TestStock.Dto.CustomerDtos;
using TestStock.Dto.UserDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class AuthManager /*: IAuthService*/
    {
        private ProjectDbContext _context;
        private IConfiguration _config;
        public AuthManager(ProjectDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        //public IDataResponse<CustomerSignInDto> Login(string mail, string password)
        //{
        //    var customer = _context.Customers.SingleOrDefault(x => x.Email == mail && x.Password == password);
        //    var user = Authenticate(customer.Password , customer.Email);
        //    var customerSigninDto = new CustomerSignInDto();
        //    if (user !=null)
        //    {
        //        var dto = new CustomerCreateDto
        //        {
        //            Email = user.Data.Email,
        //            UserName = user.Data.UserName,  
        //            Password = user.Data.Password,
        //            CustomerSurname=user.Data.CustomerSurname,
        //            PhoneNumber=user.Data.PhoneNumber,

                    
        //        };
        //        var token = Generate( dto);
        //        customerSigninDto = new CustomerSignInDto
        //        {
        //            Mail = mail,
        //            Password = password
        //        };
        //        return new DataResponse<CustomerSignInDto>(customerSigninDto, true, "giriş başarılı");
        //    }
        //    return new DataResponse<CustomerSignInDto>(customerSigninDto, false, "username or password incorrect");
        //}

        //public string Generate(CustomerCreateDto dto)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, dto.CustomerName),
        //        new Claim(ClaimTypes.GivenName, dto.UserName),
        //        new Claim(ClaimTypes.Email, dto.Email),
        //        new Claim(ClaimTypes.Surname, dto.CustomerSurname),
        //        new Claim(ClaimTypes.MobilePhone, dto.PhoneNumber),
        //        new Claim(ClaimTypes.NameIdentifier, dto.Password) //düzelt
               
        //    };

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials:credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);



        //}
        //public IDataResponse<Customer> Authenticate( string mail, string password)
        //{
        //    var currentUser = _context.Customers.SingleOrDefault(x => x.Email.ToLower() == mail && x.Password.ToLower() == password);
        //    if (currentUser != null)
        //    {
        //        return  new DataResponse<Customer>(currentUser, true);
               
        //    }
        //    return null;
        //}

        //public IDataResponse<bool> Login(CustomerSignInDto customerSignInDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
