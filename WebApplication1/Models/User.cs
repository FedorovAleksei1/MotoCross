﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MotoCross.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Moto> Motos { get; set; }
        public List<Order> Orders { get; set; }
    }
}
