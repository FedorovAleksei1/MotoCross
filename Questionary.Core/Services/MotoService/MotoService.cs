using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using Questionary.Infrastructure.Migrations;
using System.Collections.Generic;
using System.Linq;

namespace MotoCross.Services.MotoService
{
    public class MotoService : IMotoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MotoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MotoDto> GetAllByUserId(string userId)
        {
            var motos = _context.Motoes.Where(x => x.UserId == userId && !x.IsDeleted);
            var motosDto = _mapper.Map<IEnumerable<MotoDto>>(motos);
            return motosDto;
        }

        public void Create(MotoDto motoDto)
        {
            var entity = _mapper.Map<Moto>(motoDto);
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(MotoDto motoDto)
        {
            var exist = _context.Motoes.Where(x => x.Id == motoDto.Id).AsNoTracking().FirstOrDefault();
            if (exist != null)
            {
                exist = _mapper.Map<Moto>(motoDto);
                _context.Update(exist);
                _context.SaveChanges();
            }
        }


        public void Create(IEnumerable<MotoDto> motosDto)
        {
            if (motosDto == null || !motosDto.Any())
                return;

            var motoes = _mapper.Map<IEnumerable<Moto>>(motosDto);
            _context.Motoes.AddRange(motoes);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var moto = _context.Motoes.FirstOrDefault(x => x.Id == id);
            moto.IsDeleted = true;
            _context.Update(moto);
            _context.SaveChanges();
        }
    }
}
