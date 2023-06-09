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

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(r => r.СustomerService.Name)).ReverseMap();
        }
    }
}
