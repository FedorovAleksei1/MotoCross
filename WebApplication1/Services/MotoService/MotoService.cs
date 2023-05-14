using AutoMapper;
using MotoCross.Data;
using MotoCross.Dto;
using MotoCross.Models;
using System.Collections.Generic;

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

        public void Create(List<MotoDto> motosDto)
        {
            if (motosDto == null || motosDto.Count == 0)
                return;
            
                var motoes = _mapper.Map<Moto>(motosDto);
                _context.Motos.AddRange(motoes);
                _context.SaveChanges();
            
        }
    }
}
