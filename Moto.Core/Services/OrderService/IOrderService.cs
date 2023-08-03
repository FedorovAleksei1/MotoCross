using Moto.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoCross.Services.OrderService
{
    public interface IOrderService
    {
        PaginationDto<OrderDto> GetOrder(string userName, int page, int take);
        List<OrderDto> GetOrder(string userName);
        PaginationDto<OrderDto> GetAllOrder(int page, int take);
        OrderDto GetById(int id);
        void Confirmation(OrderDto orderDto);

        void AdminConfirmation(OrderDto orderDto);

        public void Create(OrderDto orderDto);
        public void Edit(OrderDto orderDto);
        public void Delete(int id);
    }
}
