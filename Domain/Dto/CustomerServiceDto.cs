using MotoCross.Models;

namespace Domain.Dto
{
    public class CustomerServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
