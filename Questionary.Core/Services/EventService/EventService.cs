using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using Questionary.Core.Services.ImportantService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.EventService
{
   
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImportantService _importantService;
        public EventService(ApplicationDbContext context, IMapper mapper, IImportantService importantService)
        {
            _context = context;
            _mapper = mapper;
            _importantService = importantService;
        }

        public IEnumerable<EventDto> ListEventsDto()
        {
            var events = _context.Events.Include(e => e.Important).AsEnumerable();
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);
            return eventsDto;
        }

        public EventDto GetEventById(int id)
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

        public IEnumerable<DateTime> GetDateByImportantId(int id)
        {
            IEnumerable<DateTime> dataList;
             dataList = _context.Events.Where(e =>e.ImportantId == id).Select(x => x.DateStart);
            return dataList;
        }

		public PaginationDto<EventDto> EventsWithMonth(int month/*, int page, int take*/)
		{
			var events = _context.Events.Include(e => e.Important).Include(x => x.Photo)
                .Where(x => x.DateStart.Month == month).OrderBy(d => d.DateStart)
				//.Skip((page - 1) * take)
				//.Take(take)
				.AsEnumerable();
           
            var paginationDto = new PaginationDto<EventDto>();
			paginationDto.Elements = _mapper.Map<List<EventDto>>(events);
            //paginationDto.TotalCount = _context.Events
            //	.Where(x => x.DateStart.Month == month)
            //	.Count();
            foreach (var even in paginationDto.Elements)
            {
                if (even.Photo != null && even.Photo.Base64 != null && even.Photo.Base64.Length > 0)
                {
                    string basePhoto64 = Convert.ToBase64String(even.Photo.Base64);
                    even.BasePhoto64 = $"data:image/png;base64,{basePhoto64}";
                }
            }
            GetDateRange(paginationDto.Elements);
			return paginationDto;
		}

		private static void GetDateRange(IEnumerable<EventDto> eventsDto)
		{
			if (eventsDto.Any())
			{
				foreach (var eventDto in eventsDto)
				{
					var endDate = eventDto.DateAnd.HasValue ? "-" + eventDto.DateAnd.Value.Day.ToString() : "";
					eventDto.DateRange = eventDto.DateStart.Day + endDate;
				}
			}
		}
	}
}
