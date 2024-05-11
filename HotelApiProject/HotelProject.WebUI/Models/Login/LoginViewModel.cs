using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
