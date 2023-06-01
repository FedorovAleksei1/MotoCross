using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Сloth
    {
        public int Id { get; set; }
        public string Price { get; set; }
        public int CategoryClouthId { get; set; }
        public CategoryClouth CategoryClouth { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
        public List<Size> Sizes { get; set; }

    }
}
