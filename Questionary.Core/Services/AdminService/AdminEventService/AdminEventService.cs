using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotoCross.Data;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Core.Services.ImportantService;
using Questionary.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
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
            var events = _context.Events.Include(e => e.Important).Include(x => x.Photo).OrderBy(d => d.Id).AsEnumerable();
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);

            foreach (var eventItem in eventsDto)
            {
                if (eventItem.Photo != null && eventItem.Photo.Base64 != null && eventItem.Photo.Base64.Length > 0)
                {
                    string basePhoto64 = Convert.ToBase64String(eventItem.Photo.Base64);
                    eventItem.BasePhoto64 = $"data:image/png;base64,{basePhoto64}";
                }
            }

            return eventsDto;
        }

        public EventDto GetAdminEventById(int id)
        {
            var eventdto = new EventDto();
            var evetn = _context.Events.Include(e => e.Important).Include(x => x.Photo).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (evetn != null)
            {
                //eventdto.Id = evetn.Id;
                //eventdto.Name = evetn.Name;
                //eventdto.DateStart = evetn.DateStart;
                //eventdto.DateAnd = evetn.DateAnd;
                //eventdto.ImportantId = evetn.ImportantId;
                //eventdto.

                if (evetn.Photo != null && evetn.Photo.Base64 != null && evetn.Photo.Base64.Length > 0)
                {
                    eventdto = _mapper.Map<EventDto>(evetn);
                    eventdto.BasePhoto64 = $"data:image/png;base64,{Convert.ToBase64String(evetn.Photo.Base64)}";
                }
                return eventdto;

            }
            return null;
        }

        public void CreateAdminEvent(EventDto eventDto)
        {
            if (eventDto == null)
                throw new Exception("Объект не может быть пустым");
            var even = _mapper.Map<Event>(eventDto);

            _context.Events.Add(even);
            _context.SaveChanges();
        }

        public void EditAdminEvent(EventDto eventDto, IFormFile photo)
        {
            //if (photo == null)
            //{
            //    eventDto.PhotoId = null;
            //}

            if (photo != null)
            {
                MemoryStream str = new();
                photo.CopyTo(str);

                var photoDto = new PhotoDto
                {
                    Base64 = str.ToArray(),
                    NameFile = photo.FileName
                };
                eventDto.Photo = photoDto;
                //eventDto.PhotoId = null;
            }

            var eventEntity = _mapper.Map<Event>(eventDto);

            _context.Update(eventEntity);
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
