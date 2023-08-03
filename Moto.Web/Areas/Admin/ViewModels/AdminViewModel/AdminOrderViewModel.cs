using Domain.Dto;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminOrderViewModel
    {

        public AdminOrderViewModel(PaginationDto<OrderDto> orders)
        {
            Orders = orders;
        }
        public AdminOrderViewModel()
        {

        }
        public OrderDto Order { get; set; }
        public UserDto User { get; set; }

        public PaginationDto<OrderDto> Orders { get; set; }

        public Dictionary<OrderDto, UserDto> Dictionaryobject { get; set; } = new();

        
    }
}
