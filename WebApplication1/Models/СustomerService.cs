using System.Collections.Generic;

namespace MotoCross.Models
{
    /// <summary>
    /// Таблица Услуги для таблицы Заказы (Какие услуги проводились для мотоцикла )
    /// </summary>
    public class СustomerService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
