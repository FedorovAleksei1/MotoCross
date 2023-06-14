using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Data;
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
            var motos = _context.Motoes.Where(x => x.UserId == userId);
            var motosDto = _mapper.Map<IEnumerable<MotoDto>>(motos);
            return motosDto;
        }

        public void Create(IEnumerable<MotoDto> motosDto)
        {
            if (motosDto == null || !motosDto.Any())
                return;
            
                var motoes = _mapper.Map<IEnumerable<Moto>>(motosDto);
                _context.Motoes.AddRange(motoes);
                _context.SaveChanges();
            
        }
    }
}
