using System;

namespace Domain.Models
{
    public class InfoUser : BaseEntity
    {
        public int Id { get; set; }

        public DateTime Year { get; set; }
        public string Facts { get; set; }
        public string StartNumber { get; set; }
        public string Experience { get; set; }
        /// <summary>
        /// Приход в анархию
        /// </summary>
        public string YearAnarch { get; set; }
        public string Hobby { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
