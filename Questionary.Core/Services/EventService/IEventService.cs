using Domain.Dto;
using System;
using System.Collections.Generic;

namespace Questionary.Core.Services.EventService
{
    public interface IEventService
    {
        IEnumerable<EventDto> ListEventsDto();

        EventDto GetEventById(int id);

        IEnumerable<DateTime> GetDateByImportantId(int id);

        PaginationDto<EventDto> EventsWithMonth(int month, int page, int take);
	}
}
