using Domain.Models;
using System;

namespace Domain.Dto
{
    public class OrderDto : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool AdminOrderConfirmed { get; set; }
        public string Name { get; set; }
        public string ComentAdmin { get; set; }
        public int? СustomerServiceId { get; set; }
        public int? MotoId { get; set; }
        public string? UserId { get; set; }
    }
}
