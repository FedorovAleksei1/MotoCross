using System;
using System.Collections.Generic;

namespace Domain.Models
{
    /// <summary>
    /// Таблица Заказы для страницы ЛК вкалдки мои заказы
    /// </summary>
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool AdminOrderConfirmed { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int? MotoId { get; set; }
        public Moto Moto { get; set; }
        public int СustomerServiceId { get; set; }
        public СustomerService СustomerService { get; set; }
    }
}
