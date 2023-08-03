using Moto.Domain.Dto;

namespace MotoCross.Services.CustomerServiceService
{
    public interface ICustomerServiceService
    {
        CustomerServiceDto GetCustomerServiceDtoById(int id);
        public void AddInOrders(CustomerServiceDto entity, string context);
    }
}
