using System;

namespace Domain.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Price { get; set; }
        public bool IsConfirmed { get; set; }
        public string Name { get; set; }
        public int? MotoId { get; set; }
        public string UserId { get; set; }
    }
}
