﻿using MotoCross.Models;

namespace MotoCross.Dto
{
    public class MotoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public OrderDto Order { get; set; }
    }
}
