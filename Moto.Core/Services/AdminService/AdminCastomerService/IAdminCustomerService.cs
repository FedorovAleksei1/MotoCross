using Domain.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminCastomerService
{
    public interface IAdminCustomerService
    {
        IEnumerable<CustomerServiceDto> AllCustomerService();
        CustomerServiceDto GetCustomerServiceById (int id);
        void CreateCustomerService (CustomerServiceDto customerServiceDto);
        void EditCustomerService (CustomerServiceDto customerServiceDto, IFormFile photo);
        void DeleteCustomerService (int id);
    }
}
