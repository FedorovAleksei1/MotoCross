using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminCastomerService
{
    public class AdminCustomerService : IAdminCustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdminCustomerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<CustomerServiceDto> AllCustomerService()
        {
           var customerServices = _context.CustomerServices.Include(x => x.Photo).Where(x => !x.IsDeleted).OrderBy(x => x.Photo != null).OrderBy(d => d.Id).AsEnumerable();
           var customerServiceDto = _mapper.Map<IEnumerable<CustomerServiceDto>>(customerServices);
            foreach (var customer in customerServiceDto)
            {
                if (customer.Photo != null && customer.Photo.Base64 != null && customer.Photo.Base64.Length > 0)
                {
                    string basePhoto64 = Convert.ToBase64String(customer.Photo.Base64);
                    customer.BasePhoto64 = $"data:image/png;base64,{basePhoto64}";
                }
            }
            return customerServiceDto;
        }


        public CustomerServiceDto GetCustomerServiceById(int id)

        {
            var customerServicedto = new CustomerServiceDto();
            var customerService = _context.CustomerServices.Include(x => x.Photo).FirstOrDefault(c => c.Id == id);
        

            if (customerService != null)
            {

                if (customerService.Photo != null && customerService.Photo.Base64 != null && customerService.Photo.Base64.Length > 0)
                {
                    customerServicedto = _mapper.Map<CustomerServiceDto>(customerService);
                    customerServicedto.BasePhoto64 = $"data:image/png;base64,{Convert.ToBase64String(customerService.Photo.Base64)}";
                }
                

            }
            return customerServicedto;
        }
        public void CreateCustomerService(CustomerServiceDto customerServiceDto)
        {
            if (customerServiceDto == null)
                throw new Exception("Объект не может быть пустым");
            var customerService = _mapper.Map<СustomerService>(customerServiceDto);

            _context.CustomerServices.Add(customerService);
            _context.SaveChanges();
        }

        public void EditCustomerService(CustomerServiceDto customerServiceDto, IFormFile photo)
        {
            if (customerServiceDto == null)
                throw new Exception("Объект не может быть пустым");
            if (photo != null)
            {
                MemoryStream str = new();
                photo.CopyTo(str);

                var photoDto = new PhotoDto
                {
                    Base64 = str.ToArray(),
                    NameFile = photo.FileName
                };
                customerServiceDto.Photo = photoDto;
                //eventDto.PhotoId = null;
            }
            var customerService = _mapper.Map<СustomerService>(customerServiceDto);
            _context.CustomerServices.Update(customerService);
            _context.SaveChanges();
        }

        public void DeleteCustomerService(int id)
        {
            if (id > 0)
            {
                var customerService = _context.CustomerServices.Find(id);
                _context.Remove(customerService);
                _context.SaveChanges();
            }
        }

       

       
    }
}
