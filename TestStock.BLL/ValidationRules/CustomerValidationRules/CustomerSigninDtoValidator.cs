using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Dto.CustomerDtos;

namespace TestStock.BLL.ValidationRules.CustomerValidationRules
{
    public class CustomerSigninDtoValidator:AbstractValidator<CustomerSignInDto>
    {
        public CustomerSigninDtoValidator()
        {
            RuleFor(x => x.Mail).NotNull().WithMessage("Lütfen kullanıcı adı giriniz!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen doğru bir mail giriniz!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre giriniz !");

        }
    }
}
