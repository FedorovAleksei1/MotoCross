using Domain.Models;
using Microsoft.AspNetCore.Identity;
using MotoCross.Models;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        //Модель для личного кабинета
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public InfoUser Info { get; set; }
        public Balans Balans { get; set; }
        //Связь С таблицей Moto так как для заполнения ЛК необходимо внести названия мотоциклов
        public List<Moto> Motos { get; set; }
        public List<Order> Orders { get; set; }
    }
}
