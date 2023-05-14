using AutoMapper;
using MotoCross.Dto;
using MotoCross.Models;

namespace MotoCross.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<Moto, MotoDto>();

            CreateMap<MotoDto, Moto>();
        }
    }
}
