using Domain.Dto;
using System.Collections.Generic;

namespace Domain.Models.ViewModel
{
    public class OrderViewModel
    {
        public OrderViewModel(List<OrderDto> orders) {
            Orders = orders;
        }
        public OrderViewModel() {
            
        }
        public OrderDto Order { get; set; }
        public UserDto User { get; set; }
       
        public List<OrderDto> Orders { get; set; }

        public Dictionary<OrderDto, UserDto> Dictionaryobject { get; set; } = new();
    }
}
