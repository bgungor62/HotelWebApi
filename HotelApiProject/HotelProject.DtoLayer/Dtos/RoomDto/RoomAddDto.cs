﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Oda numarası boş geçilemez!")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Oda Ücreti boş geçilemez!")]
        public int Price { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Yatak sayısı boş geçilemez!")]
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Fotoğraf boş geçilemez!")]
        public string CoverImage { get; set; }
    }
}
