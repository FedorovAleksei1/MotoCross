using AutoMapper;
using Moto.Domain.Dto;
using Moto.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MotoCross.Data;
using MotoCross.Services.UserService;
using System;
using System.Data;
using System.Linq;

namespace MotoCross.Services.CustomerServiceService
{
    public class CustomerServiceService : ICustomerServiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CustomerServiceService(ApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
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
        public async void AddInOrders(CustomerServiceDto entity, string context)
        {
            if (entity == null)
                throw new Exception("Объект не может быть пустым");

            var user = await _userService.GetUserByName(context);
            if (user != null)
            {
                var order = _context.Orders.FirstOrDefault(c => c.Id == entity.OrderId);
                if (order == null)
                {
                    order = new Order()
                    {
                        Data = DateTime.Now,
                        IsConfirmed = false,
                        IsDeleted = false,
                        Price = entity.Price,

                        СustomerServiceId = entity.Id,
                        UserId =  user.Id

                    };
                    _context.Orders.Add(order);
                }
                else
                {
                    order.СustomerService = _mapper.Map<СustomerService>(entity);
                    _context.Orders.Update(order);
                }

                _context.SaveChanges();
            }


        }
    }
}
