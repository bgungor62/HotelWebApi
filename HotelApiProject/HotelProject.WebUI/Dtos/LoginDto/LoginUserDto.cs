using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage="Kullanıcı adı boş bırakılamaz!")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Şifre giriniz!")]
        public string Password { get; set; }
    }
}
