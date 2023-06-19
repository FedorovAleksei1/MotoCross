using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModel
{
    public class EventListViewModel
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public PaginationDto<EventDto> Item { get; set; }
    }
}
