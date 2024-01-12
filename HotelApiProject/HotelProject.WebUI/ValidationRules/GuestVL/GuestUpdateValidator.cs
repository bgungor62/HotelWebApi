using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestVL
{
    public class GuestUpdateValidator:AbstractValidator<UpdateGuestDto>
    {
        public GuestUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez..");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı soyadı boş geçilemez..");
            RuleFor(x => x.City).NotEmpty().WithMessage("Kullanıcı şehir alanı  boş geçilemez..");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olamaz!");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir Alanı 3 karakterden az olamaz");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Kullanıcı Mail Boş geçilemez!").EmailAddress().WithMessage("Kullanıcının Mail Adresi Geçersizdir!");
        }
    }
}
