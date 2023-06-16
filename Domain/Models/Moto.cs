using System.Collections.Generic;

namespace Domain.Models
{
    public class Moto : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
