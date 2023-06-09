﻿using System;

namespace Domain.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateAnd { get; set; }
        public int ImportantId { get; set; }
        public string DateRange { get; set; }
        public ImportantDto Important { get; set; }
    }
}
