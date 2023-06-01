using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Data;
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
                _context.Motoes.AddRange(motoes);
                _context.SaveChanges();
            
        }
    }
}
