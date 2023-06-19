using Domain.Dto;
using System.Collections.Generic;

namespace Domain.Models.ViewModel
{
    public class OrderViewModel
    {
        public OrderViewModel(List<OrderDto> orders) {
            Orders = orders;
        }

        public List<OrderDto> Orders { get; set; }
    }
}
