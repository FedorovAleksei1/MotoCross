﻿using AutoMapper;
using MotoCross.Data;
using System.Linq;
using System;
using MotoCross.Models;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Dto;
using Domain.Models;
using Questionary.Infrastructure.Migrations;

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
                .Where(t => t.User.UserName == userName && !t.IsDeleted).OrderByDescending(d => d.Id).ToList();

            return _mapper.Map<List<OrderDto>>(order);
        }

        public void Confirmation(OrderDto orderDto)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderDto.Id);
            if (!order.IsConfirmed)
            {
                order.IsConfirmed = true;
                _context.Update(order);
                _context.SaveChanges();
            }
        }

        public void AdminConfirmation(OrderDto orderDto)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderDto.Id);
            if (!order.AdminOrderConfirmed)
            {
                order.AdminOrderConfirmed = true;
                _context.Update(order);
                _context.SaveChanges();
            }
        }

        public OrderDto GetById(int id)
        {
            var orderDto = new OrderDto();

            var order = _context.Orders.Include(o => o.СustomerService).FirstOrDefault(x => x.Id == id);
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
