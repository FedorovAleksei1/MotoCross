using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class СustomerService : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Individual { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
        public List<Order> Orders { get; set; }
    }
}
