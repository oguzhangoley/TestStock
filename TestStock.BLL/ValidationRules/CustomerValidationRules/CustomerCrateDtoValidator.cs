using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Dto.CustomerDtos;

namespace TestStock.BLL.ValidationRules.CustomerValidationRules
{
    public class CustomerCrateDtoValidator:AbstractValidator<CustomerCreateDto>
    {
        public CustomerCrateDtoValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Ad alanı boş geçilemez !");
            RuleFor(x => x.CustomerName).MinimumLength(2).WithMessage("Ad alanı en az 2 harften oluşmalıdır");

            RuleFor(x => x.CustomerSurname).NotEmpty().WithMessage("Soyad alanı boş geçilemez !");
            RuleFor(x => x.CustomerSurname).MinimumLength(2).WithMessage("Soyad alanı en az 2 harften oluşmalıdır");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez !");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 harften oluşmalıdır");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez !");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası alanı boş geçilemez !");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez !");
        }
    }
}
