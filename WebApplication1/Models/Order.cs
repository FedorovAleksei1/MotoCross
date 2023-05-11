using System;
using System.Collections.Generic;

namespace MotoCross.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MotoId { get; set; }
        public Moto Moto { get; set; }
        public List<СustomerService> СustomerServices { get; set; }
    }
}
