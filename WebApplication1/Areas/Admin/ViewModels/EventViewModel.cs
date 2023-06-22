﻿using Domain.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModel
{
    public class EventViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public string MonthName { get; set; }
        public PaginationDto<EventDto> Item { get; set; }
        public Dictionary<int, IEnumerable<DateTime>> ImportantDayList { get; set; }
        public List<EventDto> Events { get; set; } = new();
    }
}
