using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Core.Services.ImportantService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminEventService
{
    public class AdminEventService : IAdminEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAdminImportantService _importantService;
        public AdminEventService(ApplicationDbContext context, IMapper mapper, IAdminImportantService importantService)
        {
            _context = context;
            _mapper = mapper;
            _importantService = importantService;
        }

        public IEnumerable<EventDto> ListAdminEventsDto()
        {
            var events = _context.Events.Include(e => e.Important).AsEnumerable();
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);
            return eventsDto;
        }

        public EventDto GetAdminEventById(int id)
        {
            var eventdto = new EventDto();
            var evetn = _context.Events.Include(e => e.Important).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (evetn != null)
            {
                eventdto.Id = evetn.Id;
                eventdto.Name = evetn.Name;
                eventdto.DateStart = evetn.DateStart;
                eventdto.DateAnd = evetn.DateAnd;
                eventdto.ImportantId = evetn.ImportantId;
            }
            return eventdto;
        }

        public void CreateAdminEvent(EventDto eventDto)
        {
            if (eventDto == null)
                throw new Exception("Объект не может быть пустым");
            var even = _mapper.Map<Event>(eventDto);

            _context.Events.Add(even);
            _context.SaveChanges();
        }

        public void EditAdminEvent(EventDto eventDto)
        {
            if (eventDto == null)
                throw new Exception("Объект не может быть пустым");
            var even = _mapper.Map<Event>(eventDto);
            _context.Update(even);
            _context.SaveChanges();
        }

        public void DeleteAdminEvent(int id)
        {
            if (id > 0)
            {
                var even = _context.Events.Find(id);
                _context.Remove(even);
                _context.SaveChanges();
            }
        }


    }
}
