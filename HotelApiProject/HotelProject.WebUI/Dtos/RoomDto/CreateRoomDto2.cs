﻿namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class CreateRoomDto2
    {
        public string RoomNumber { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImage { get; set; }
    }
}
