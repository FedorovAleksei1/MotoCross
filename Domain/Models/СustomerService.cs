using MotoCross.Models;
using System.Collections.Generic;

namespace Domain.Models
{
    /// <summary>
    /// Таблица Услуги для таблицы Заказы (Какие услуги проводились для мотоцикла )
    /// </summary>
    public class СustomerService : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
