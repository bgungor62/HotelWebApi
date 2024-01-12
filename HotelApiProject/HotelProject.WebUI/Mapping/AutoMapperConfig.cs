﻿using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DtoLayer.Dtos.Guest;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.DtoLayer.Dtos.StaffDto;
using HotelProject.DtoLayer.Dtos;
using AutoMapper;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            //Guest
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

            //Contact
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<GetMessageByIdDto, Contact>().ReverseMap();


            //SendMessage
            CreateMap<CreateSendMessage, SendMessage>().ReverseMap();
            CreateMap<ResultSendMessageDto, SendMessage>().ReverseMap();
            CreateMap<GetMessageByIdDto, SendMessage>().ReverseMap();

            //MessageCategory
            CreateMap<ResultSendMessageDto, MessageCategory>().ReverseMap();



        }
    }
}
