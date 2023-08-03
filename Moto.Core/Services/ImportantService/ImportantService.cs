using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.ImportantService
{
    public class ImportantService : IImportantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ImportantService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ImportantDto> ListImportantsDto()
        {
            var importans = _context.Importants.ToList();
            var importansDto = _mapper.Map<List<ImportantDto>>(importans);
            return importansDto;
        }
        public ImportantDto GetImportantById(int id)
        {
            var importantdto = new ImportantDto();
            var important = _context.Importants.Include(i => i.Events).FirstOrDefault(f => f.Id == id);
            if (important != null)
            {
                //importantdto.Id = important.Id;
                //important.Name = important.Name;
                //importantdto.
                return _mapper.Map<ImportantDto>(important);

            }
            return importantdto;
        }

        
    }
}
