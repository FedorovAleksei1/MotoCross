using Domain.Dto;
using System;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.VIewModel
{
    public class EventViewModel
    {

        public Dictionary<int, IEnumerable<DateTime>> ImportantDayList { get; set; }
        public List<EventDto> Events { get; set; } = new();
    }
}
