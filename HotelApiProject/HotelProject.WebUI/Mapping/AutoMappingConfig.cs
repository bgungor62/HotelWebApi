using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            //Service dto
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            //register dto
            CreateMap<CreateAppUserDto, AppUser>().ReverseMap(); 

            //Login dto
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            //About dto
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            //Staff dto
            CreateMap<ResultStaffDto,Staff>().ReverseMap();

            //Subscribe dto
            CreateMap<CreatetSubscribeDto,Subscribe>().ReverseMap();

            //Booking dto
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedResarvationDto, Booking>().ReverseMap();

            //Contact

            CreateMap<CreateContactDto,Contact>().ReverseMap();



        }
    }
}
