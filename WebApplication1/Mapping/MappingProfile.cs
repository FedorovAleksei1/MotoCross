using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Models;
using Questionary.Core.Services.AdminService.AdminBalansService;

namespace MotoCross.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Moto, MotoDto>().ReverseMap();
            CreateMap<EventDto, Event>().ReverseMap()
                .ForMember(x => x.BasePhoto64, (option) => option.Ignore())
                .ForMember(x => x.DateRange, (option) => option.Ignore());
            CreateMap<Important, ImportantDto>().ReverseMap();
            CreateMap<InfoUser, InfoUserDto>().ReverseMap();
            CreateMap<CardTeamUser, CardTeamUserDto>().ReverseMap()
                /*.ForMember(x => x.UploadPhoto, (option) => option.Ignore())*//*.ForMember(t => t.PhotoBase64, rep => rep.MapFrom(ped => ped.PhotoId != null ? ped.Photo.Base64 : ""))*/;

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.СustomerService.Name)).ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<FormedTeam, FormedTeamDto>().ReverseMap();
            CreateMap<Balans, BalansDto>().ReverseMap();
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<СustomerService, CustomerServiceDto>().ReverseMap();
            CreateMap<OperationUser, OperationUserDto>().ReverseMap();


        }
    }
}
