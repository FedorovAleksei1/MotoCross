using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Event : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateAnd { get; set; }
        public string? InfoEvent { get; set; }
        public string DateRange { get; set; }
        public int ImportantId { get; set; }
        public Important Important { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
