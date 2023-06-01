using Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoCross.Services.OrderService
{
    public interface IOrderService
    {
        List<OrderDto> GetOrder(string userName);
        OrderDto GetById(int id);
        void Confirmation(OrderDto orderDto);
    }
}
