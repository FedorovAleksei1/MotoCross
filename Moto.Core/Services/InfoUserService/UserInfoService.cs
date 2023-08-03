using AutoMapper;
using Moto.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MotoCross.Services.InfoUserService
{
    public class UserInfoService : IUserInfoService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public UserInfoService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public InfoUserDto GetByUserId(string userId)
        {
            var info = _context.Infoes.FirstOrDefault(x => x.UserId == userId);
            var infoDto = _mapper.Map<InfoUserDto>(info);
            return infoDto;
        }

		public IEnumerable<InfoUserDto> GetAll()
        {
            var info = _context.Infoes.Include(i => i.User).AsEnumerable();
            var infoesDto = _mapper.Map<IEnumerable<InfoUserDto>>(info);
            return infoesDto;
        }
    }
}
