using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
         public int RoomID { get; set; }
        [Required(ErrorMessage = "Oda numarası boş geçilemez!")]
        public string RoomNumber { get; set; }
        
        [Required(ErrorMessage = "Oda Ücreti boş geçilemez!")]
        public int Price { get; set; }
      
        [Required(ErrorMessage = "Başlık boş geçilemez!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Yatak sayısı boş geçilemez!")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Banyo sayısı boş geçilemez!")]
        public string BathCount { get; set; }

        [Required(ErrorMessage = "Wifi bilgisi boş geçilemez!")]
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fotoğraf boş geçilemez!")]
        public string CoverImage { get; set; }
    }
}

