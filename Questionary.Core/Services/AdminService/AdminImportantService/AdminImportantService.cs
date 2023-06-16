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

namespace Questionary.Core.Services.AdminService.AdminImportantService
{
    public class AdminImportantService : IAdminImportantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AdminImportantService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ImportantDto> ListImportansDto()
        {
            var importans = _context.Importants.ToList();
            var importansDto = _mapper.Map<List<ImportantDto>>(importans);
            return importansDto;
        }

        public ImportantDto GetImportanById(int id)
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

        public void CreateImportant(ImportantDto importanDto)
        {
            if(importanDto == null)
                throw new Exception("Объект не может быть пустым");
            var importan = _mapper.Map<Important>(importanDto);

            _context.Importants.Add(importan);
            _context.SaveChanges();
        }

        public void EditImportan(ImportantDto importanDto)
        {
            if (importanDto == null)
                throw new Exception("Объект не может быть пустым");
            var importan = _mapper.Map<Important>(importanDto);
            _context.Update(importan);
            _context.SaveChanges();
        }

        public void DeleteImportan(int id)
        {
            if (id > 0)
            {
                var importan = _context.Importants.Find(id);
                _context.Remove(importan);
                _context.SaveChanges();
            }
        }

    }
}
