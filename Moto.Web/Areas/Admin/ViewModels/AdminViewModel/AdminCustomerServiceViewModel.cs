using Moto.Domain.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminCustomerServiceViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public UserDto User { get; set; }
        public CustomerServiceDto Customer { get; set; }
       public IEnumerable <CustomerServiceDto> Customers { get; set; }
    }
}
