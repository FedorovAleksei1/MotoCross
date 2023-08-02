using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using Questionary.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminCardNamePutMoney
{
    public class CardNamePutMoneyService : ICardNamePutMoneyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CardNamePutMoneyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CardNameOnputMoneyDto> GetCardNameOnputMoney()
        {
            var cards = _context.CardNamePutMoneys.Include(x => x.User).Include(x=>x.Card).ToList();
            var cardsDto = _mapper.Map<List<CardNameOnputMoneyDto>>(cards);
            return cardsDto;
        }
        public CardNameOnputMoneyDto CardNameOnputMoneyById(int id)
        {
            var card = _context.CardNamePutMoneys.FirstOrDefault(f => f.Id == id);
            var cardDto = _mapper.Map<CardNameOnputMoneyDto>(card);
            return cardDto;
        }

        public void Create(CardNameOnputMoneyDto cardNameOnputMoneyDto)
        {
            if (cardNameOnputMoneyDto == null)
                throw new Exception("Объект не может быть пустым");
            var card = _mapper.Map<CardNameOnputMoney>(cardNameOnputMoneyDto);



            _context.CardNamePutMoneys.Add(card);
                _context.SaveChanges();
          

            
        }

      

        public void Edit(CardNameOnputMoneyDto cardNameOnputMoneyDto)
        {
            if (cardNameOnputMoneyDto == null)
                throw new Exception("Объект не может быть пустым");
            var card = _mapper.Map<CardNameOnputMoney>(cardNameOnputMoneyDto);
            _context.Update(card);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var card = _context.CardNamePutMoneys.FirstOrDefault(c => c.Id == id);
            _context.Remove(card);
            _context.SaveChanges();
        }

    }
}
