using MotoCross.Models;
using System.Collections.Generic;
using System;

namespace MotoCross.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int MotoId { get; set; }
        public MotoDto Moto { get; set; }
        public List<СustomerServiceDto> СustomerServices { get; set; }
    }
}
