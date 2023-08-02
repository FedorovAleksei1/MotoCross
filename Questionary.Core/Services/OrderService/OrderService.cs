using AutoMapper;
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


        public PaginationDto<OrderDto> GetOrder(string userName, int page, int take)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Пользователь не найден");


            var order = _context.Orders.Include(o => o.СustomerService)
                .Where(t => t.User.UserName == userName && !t.IsDeleted).OrderByDescending(d => d.Id).ToList();



            var totalCount = order.Count();
            var cardTeams = order
                .Skip((page - 1) * take)
                .Take(take)
                .ToList();

            var orderDto = _mapper.Map<List<OrderDto>>(cardTeams);
            var paginationDto = new PaginationDto<OrderDto>();
            paginationDto.Page = page;
            paginationDto.Elements = _mapper.Map<List<OrderDto>>(orderDto);
            paginationDto.TotalCount = totalCount;

            return paginationDto;

        }


        public List<OrderDto> GetOrder(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Пользователь не найден");


            var order = _context.Orders.Include(o => o.СustomerService)
                .Where(t => t.User.UserName == userName && !t.IsDeleted).OrderByDescending(d => d.Id).ToList();

            return _mapper.Map<List<OrderDto>>(order);

        }


        public PaginationDto<OrderDto> GetAllOrder(int page, int take)
        {
            var order = _context.Orders.Include(o => o.СustomerService)
                .Where(t => !t.IsDeleted).OrderByDescending(d => d.Id).ToList();

            var totalCount = order.Count();
            var cardTeams = order
                .Skip((page - 1) * take)
                .Take(take)
                .ToList();



            var orderDto = _mapper.Map<List<OrderDto>>(cardTeams);
            var paginationDto = new PaginationDto<OrderDto>();
            paginationDto.Page = page;
            paginationDto.Elements = _mapper.Map<List<OrderDto>>(orderDto);
            paginationDto.TotalCount = totalCount;

            return paginationDto;
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

        public void Create(OrderDto orderDto)
        {
            if (orderDto == null)
                return;


            if (orderDto != null)
            {
                var order = new Order();
                order.Id = orderDto.Id;
                order.Data = orderDto.Data;
                order.IsConfirmed = orderDto.IsConfirmed;
                order.СustomerService = _mapper.Map<СustomerService>(orderDto.CustomerService);
                order.Price = (decimal)orderDto.Price;
                order.MotoId = orderDto.MotoId;
                order.UserId = orderDto.UserId;
                order.ComentAdmin = orderDto.ComentAdmin;
                _context.Orders.Add(order);
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
                orderDto.ComentAdmin = order.ComentAdmin;
            }


            return orderDto;
        }

        public void Edit(OrderDto orderDto)
        {
            if (orderDto == null)
                return;

            var order = _context.Orders.First(o => o.Id == orderDto.Id);

            order.UpdateDate = DateTime.Now;
            order.Price = orderDto.Price;
            order.ComentAdmin = orderDto.ComentAdmin;


            //var order = _mapper.Map<Order>(orderDto);
            _context.Orders.Update(order);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Remove(order);
            _context.SaveChanges();
        }
    }
}
