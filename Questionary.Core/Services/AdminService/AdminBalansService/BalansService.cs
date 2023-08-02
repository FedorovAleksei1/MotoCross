using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminBalansService
{
    public class BalansService : IBalansService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BalansService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BalansDto> GetAllBalans()
        {
            var balans = _context.Balanses.Include(b => b.Operation).AsEnumerable();
            var balansDto = _mapper.Map<IEnumerable<BalansDto>>(balans);
            return balansDto;
        }

        public BalansDto GetBalansByUserId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Пользователь не найден");

            var balans = _context.Balanses.Include(b => b.Operation).FirstOrDefault(b => b.User.Id == id);
            if(balans == null)
            {
                var newbalans = new BalansDto()
                {
                    
                };
            }
            var balansDto = _mapper.Map<BalansDto>(balans);
            return balansDto;

         
        }
        public void CreateBalans(BalansDto balansDto)
        {
            if (balansDto == null)
                throw new Exception("Объект не может быть пустым");
            var balans = _mapper.Map<Balans>(balansDto);

            _context.Balanses.Add(balans);
            _context.SaveChanges();
        }

        public void EditBalans(BalansDto balansDto)
        {
            if (balansDto == null)
                throw new Exception("Объект не может быть пустым");
            var balans = _mapper.Map<Balans>(balansDto);

            _context.Balanses.Update(balans);
            _context.SaveChanges();
        }
    
    }
}
