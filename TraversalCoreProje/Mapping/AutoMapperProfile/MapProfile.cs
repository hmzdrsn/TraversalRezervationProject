﻿using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto,Announcement>().ReverseMap();
            CreateMap<AnnouncementListDto,Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto,Announcement>().ReverseMap();

            CreateMap<AppUserLoginDTOs,AppUser>().ReverseMap();

            CreateMap<AppUserRegisterDTOs,AppUser>().ReverseMap();

            CreateMap<SendMessageDto,ContactUs>().ReverseMap();
            
        }
    }
}