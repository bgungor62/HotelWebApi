using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class CreateAppUserDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir!")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Soyad alanı gereklidir!")]
        public string Surname { get; set; }
       
        [Required(ErrorMessage = "Kullanıcı Adı alanı gereklidir!")]
        public string UserName { get; set; }
       
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi girin!")]
        [Required(ErrorMessage = "Mail alanı gereklidir!")] //buraya dikkat et
        public string Mail { get; set; }
       
        [Required(ErrorMessage = "Şifre alanı gereklidir!")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string? Password { get; set; }
        
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor,kontrol edip tekrar deneyiniz!")]
        public string? ConfirmPassword { get; set; }
       
        [Required(ErrorMessage ="Foto alanı boş bırakıldı..")]
        public IFormFile? ImageUrl { get; set; }
      
        //ilişki worklocation
        public int WorkLocationId { get; set; }

    }
}
