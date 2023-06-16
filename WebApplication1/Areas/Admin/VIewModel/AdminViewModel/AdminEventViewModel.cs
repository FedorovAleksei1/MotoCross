using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.VIewModel.AdminViewModel
{
    public class AdminEventViewModel
    {
       
        public EventDto Event { get; set; }
        public IEnumerable<SelectListItem> ImportantsList { get; set; }
        public IEnumerable<EventDto> Events { get; set; } 
    }
}
