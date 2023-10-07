using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DtoLayer.Dtos;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.DtoLayer.Dtos.StaffDto;

namespace HotelWebApi.Mapping
{
    public class AutoMappingConfig:Profile
    {
        public AutoMappingConfig()
        {
            //Dto da oluşturduğumuz propertyler ile entitydeki propertyler ie eşleştirmiş olduk
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room,RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();  //yukarıda yaptığımız tersine işleminin aynısını yapar

            //booking
            CreateMap<BookingDto,Booking>().ReverseMap();


            //Staff
            CreateMap<StaffListDto, Staff>().ReverseMap();


        }
    }
}
