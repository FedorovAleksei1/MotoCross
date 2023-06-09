using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.VIewModel
{
    public class EventListViewModel
    {
        public string MonthName { get; set; }
        public IEnumerable<EventDto> Items { get; set; }
    }
}
