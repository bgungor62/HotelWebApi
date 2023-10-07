using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Başlık giriniz!")]
        [StringLength(30, ErrorMessage = "Başlık alanı en fazla 30 karakter olabilir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama giriniz!")]
        [StringLength(200, ErrorMessage = "Açıklama alanı en fazla 200 karakter olabilir!")]
        public string Description { get; set; }
    }
}
