using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using MotoCross.Dto;
using System;
using System.Linq;

namespace MotoCross.Services.CustomerServiceService
{
    public class CustomerServiceService : ICustomerServiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerServiceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CustomerServiceDto GetCustomerServiceDtoById(int id)
        {
            
            if (id == 0)
                throw new Exception("Id должен быть больше 0");

            var customer = _context.CustomerServices
                .FirstOrDefault(t => t.Id == id);

            if (customer == null)
                throw new Exception("Объект не найден");

            var customerdto = _mapper.Map<CustomerServiceDto>(customer);

            return customerdto;
        }
    }
}
