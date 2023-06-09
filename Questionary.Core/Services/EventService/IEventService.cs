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

        IEnumerable<EventDto> EventsWithMonth(int month);
	}
}
