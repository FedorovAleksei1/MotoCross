﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CardTeamUser : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Year { get; set; }
        public string Facts { get; set; }
        public string StartNumber { get; set; }
        public string Experience { get; set; }
        /// <summary>
        /// Приход в анархию
        /// </summary>
        public string YearAnarch { get; set; }
        public string Hobby { get; set; }
        
        public int? PhotoId { get; set; }        
        public Photo Photo { get; set; }
    }
}
