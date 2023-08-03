using Domain.Dto;
using System;
using System.Collections.Generic;

namespace Moto.Core.Services.EventService
{
    public interface IEventService
    {
        IEnumerable<EventDto> ListEventsDto();

        EventDto GetEventById(int id);

        IEnumerable<DateTime> GetDateByImportantId(int id);

        PaginationDto<EventDto> EventsWithMonthAndYear(int? month, int? year/*, int page, int take*/);
	}
}
