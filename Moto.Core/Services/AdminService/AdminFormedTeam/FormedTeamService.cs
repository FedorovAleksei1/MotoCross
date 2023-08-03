using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminFormedTeam
{
    public class FormedTeamService : IFormedTeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FormedTeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public IEnumerable<FormedTeamDto> FormedTeams()
        {
            var formTeams = _context.FormedTeams.OrderBy(d => d.Id).AsEnumerable();
            var formTeamsDto = _mapper.Map<IEnumerable<FormedTeamDto>>(formTeams);
            return formTeamsDto;
        }
        public FormedTeamDto GetFormedTeamBuId(int id)
        {
            var formTeam = _context.FormedTeams.FirstOrDefault(f => f.Id == id);
            var formTeamDto = _mapper.Map<FormedTeamDto>(formTeam);
            return formTeamDto;
        }
        public void CreateFormedTeam(FormedTeamDto formedTeam)
        {
            if (formedTeam == null)
                throw new Exception("Объект не может быть пустым");
            var formed = _mapper.Map<FormedTeam>(formedTeam);

            _context.FormedTeams.Add(formed);
            _context.SaveChanges();
        }
        public void EditFormedTeam(FormedTeamDto formedTeam)
        {
            if (formedTeam == null)
                throw new Exception("Объект не может быть пустым");
            var info = _mapper.Map<FormedTeam>(formedTeam);
            _context.Update(info);
            _context.SaveChanges();
        }

        public void DeleteFormedTeam(int id)
        {
            if (id > 0)
            {
                var formed = _context.FormedTeams.Find(id);
                _context.Remove(formed);
                _context.SaveChanges();
            }
        }

      

       

       
    }
}
