using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminCardService
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CardService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<CardDto> GetAllCardAdmin()
        {
            var cards = _context.Cards.ToList();
            var cardsDto = _mapper.Map<IEnumerable<CardDto>>(cards);
            return cardsDto;
        }
        public CardDto CardGetById(int id)
        {
            var card = _context.Cards.FirstOrDefault(f => f.Id == id);
            var cardDto = _mapper.Map<CardDto>(card);
            return cardDto;
        }

        public void CreateCard(CardDto cardNameOnputMoneyDto)
        {
            if (cardNameOnputMoneyDto == null)
                throw new Exception("Объект не может быть пустым");
            var card = _mapper.Map<Card>(cardNameOnputMoneyDto);

            _context.Cards.Add(card);
            _context.SaveChanges();
        }



        public void EditCard(CardDto cardNameOnputMoneyDto)
        {
            if (cardNameOnputMoneyDto == null)
                throw new Exception("Объект не может быть пустым");
            var card = _mapper.Map<Card>(cardNameOnputMoneyDto);
            _context.Update(card);
            _context.SaveChanges();
        }
        public void DeleteCard(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            _context.Remove(card);
            _context.SaveChanges();
        }
    }
}
