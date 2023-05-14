using MotoCross.Models;
using System.Collections.Generic;

namespace MotoCross.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<MotoDto> Motos { get; set; }
        //public List<OrderDto> Orders { get; set; }
    }
}
