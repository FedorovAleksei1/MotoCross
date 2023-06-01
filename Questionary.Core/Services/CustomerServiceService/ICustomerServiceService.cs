using Domain.Dto;

namespace MotoCross.Services.CustomerServiceService
{
    public interface ICustomerServiceService
    {
        CustomerServiceDto GetCustomerServiceDtoById(int id);
    }
}
