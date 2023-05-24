using AutoMapper;
using MotoCross.Data;
using MotoCross.Dto;
using System.Linq;
using System;
using MotoCross.Models;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MotoCross.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<OrderDto> GetOrder(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Пользователь не найден");

            var order = _context.Orders.Include(o => o.СustomerService)
                .Where(t => t.User.UserName == userName).ToList();

            return _mapper.Map<List<OrderDto>>(order);
        }

        public void Confirmation(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            if (!order.IsConfirmed)
            {
                order.IsConfirmed = true;
                _context.Update(order);
                _context.SaveChanges();
            }
        }

        public OrderDto GetById(int id)
        {
            var orderDto = new OrderDto();

            var order = _context.Orders.Include(o => o.СustomerService).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                orderDto.Id = order.Id;
                orderDto.Data = order.Data;
                orderDto.IsConfirmed = order.IsConfirmed;
                orderDto.Name = order.СustomerService.Name;
                orderDto.Price = (decimal)order.Price;
                orderDto.MotoId = order.MotoId;
                orderDto.UserId = order.UserId;
            }


            return orderDto;
        }
    }
}
