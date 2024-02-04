using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DtoLayer.Dtos;
using HotelProject.DtoLayer.Dtos.About;
using HotelProject.DtoLayer.Dtos.Guest;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.DtoLayer.Dtos.StaffDto;

namespace HotelWebApi.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            //Dto da oluşturduğumuz propertyler ile entitydeki propertyler ie eşleştirmiş olduk
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();  //yukarıda yaptığımız tersine işleminin aynısını yapar

            //booking
            CreateMap<BookingDto, Booking>().ReverseMap();


            //Staff
            CreateMap<StaffListDto, Staff>().ReverseMap();

            //about
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            //Guest
            CreateMap<AddGuestDto, Guest>().ReverseMap();



        }
    }
}
