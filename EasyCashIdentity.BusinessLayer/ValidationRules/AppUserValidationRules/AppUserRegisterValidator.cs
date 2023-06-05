using EasyCashIdentity.DTOLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor( x => x.Name).NotEmpty().WithMessage("Ad Alani Bos Gecilemez");
            RuleFor( x => x.Surname).NotEmpty().WithMessage("Soyad Alani Bos Gecilemez");
            RuleFor( x => x.Username).NotEmpty().WithMessage("Kullanici Adi Alani Bos Gecilemez");
            RuleFor( x => x.Email).NotEmpty().WithMessage("Email Alani Bos Gecilemez");
            RuleFor( x => x.Password).NotEmpty().WithMessage("Sifre Alani Bos Gecilemez");
            RuleFor( x => x.ConfirmPassword).NotEmpty().WithMessage("Sifre Tekrar Alani Bos Gecilemez");
            RuleFor( x => x.Name).MaximumLength(30).WithMessage("Lutfen 30 Karakter Giriniz");
            RuleFor( x => x.Name).MinimumLength(2).WithMessage("Lutfen En Az 2 Karakter Giriniz");
            RuleFor( x => x.ConfirmPassword ).Equal( y => y.ConfirmPassword ).WithMessage("Parola Eslesmiyor !");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lutfen Gecerli Bir Email Adresi Giriniz");
        }
    }
}
