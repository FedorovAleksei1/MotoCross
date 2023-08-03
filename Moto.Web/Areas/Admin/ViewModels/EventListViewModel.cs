using Moto.Domain.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel
{
    public class EventListViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public PaginationDto<EventDto> Item { get; set; }
    }
}
