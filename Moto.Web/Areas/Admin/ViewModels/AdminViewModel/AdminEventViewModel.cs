using Moto.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel.AdminViewModel
{
    public class AdminEventViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public EventDto Event { get; set; }
        public IEnumerable<SelectListItem> ImportantsList { get; set; }
        public IEnumerable<EventDto> Events { get; set; } 
    }
}
