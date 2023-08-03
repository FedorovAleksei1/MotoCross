using AutoMapper;
using Moto.Domain.Dto;
using Moto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminUserInfoService
{
    public class AdminUserInfoService : IAdminUserInfoService


    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public AdminUserInfoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateInfoUser(InfoUserDto infoUserDto)
        {
            if (infoUserDto == null)
                throw new Exception("Объект не может быть пустым");
            var info = _mapper.Map<InfoUser>(infoUserDto);

            _context.Infoes.Add(info);
            _context.SaveChanges();
        }

        

        public void EditInfoUSer(InfoUserDto infoUserDto)
        {
            if (infoUserDto == null)
                throw new Exception("Объект не может быть пустым");
            var info = _mapper.Map<InfoUser>(infoUserDto);
            _context.Update(info);
            _context.SaveChanges();
        }

        public IEnumerable<InfoUserDto> GetAll()
        {
            var info = _context.Infoes.Include(i => i.User).AsEnumerable();
            var infoesDto = _mapper.Map<IEnumerable<InfoUserDto>>(info);
            return infoesDto;
        }

        public InfoUserDto GetByUserId(string userId)
        {
            var info = _context.Infoes.FirstOrDefault(x => x.UserId == userId);
            var infoDto = _mapper.Map<InfoUserDto>(info);
            return infoDto;
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                var info = _context.Infoes.Find(id);
                _context.Remove(info);
                _context.SaveChanges();
            }
        }
    }
}
