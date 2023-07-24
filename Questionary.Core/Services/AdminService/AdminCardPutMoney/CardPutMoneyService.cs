using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminCardPutMoney
{
    public class CardPutMoneyService : ICardPutMoneyService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CardPutMoneyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void EditCardPutMoney(CardPutMoneyDto cardPutMoneyDto)
        {
            var cardPutMoney = _mapper.Map<CardPutMoney>(cardPutMoneyDto);
            _context.Update(cardPutMoney);
            _context.SaveChanges();
        }
    }
}
