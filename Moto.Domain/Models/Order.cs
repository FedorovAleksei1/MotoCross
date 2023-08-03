using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool AdminOrderConfirmed { get; set; }
        public string? ComentAdmin { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
        public int? MotoId { get; set; }
        public EntityMoto Moto { get; set; }
        public int? СustomerServiceId { get; set; }
        public СustomerService СustomerService { get; set; }
    }
}
