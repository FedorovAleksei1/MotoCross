using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Models;

namespace MotoCross.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Moto, MotoDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Important, ImportantDto>().ReverseMap();
            CreateMap<InfoUser, InfoUserDto>().ReverseMap();
            CreateMap<CardTeamUser, CardTeamUserDto>().ReverseMap()
                /*.ForMember(x => x.UploadPhoto, (option) => option.Ignore())*//*.ForMember(t => t.PhotoBase64, rep => rep.MapFrom(ped => ped.PhotoId != null ? ped.Photo.Base64 : ""))*/;

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.СustomerService.Name)).ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
        }
    }
}
