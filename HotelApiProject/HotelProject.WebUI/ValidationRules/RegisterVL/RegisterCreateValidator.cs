using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.WebUI.ValidationRules.RegisterVL
{
    public class RegisterCreateValidator : IPasswordValidator<AppUser>
    {     
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (password.Length < 6)//karakter sayısı
                errors.Add(new IdentityError { Code = "PasswordLength", Description = "Şifre 6 karakterden az olamaz.." });
            if (password.ToLower().Contains(user.UserName.ToLower()))
                errors.Add(new IdentityError { Code = "PasswordContainsUserName", Description = "Şifre içerisinde kullanıcı adınızı yazmayınız." });
            if (!errors.Any())
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }
}
