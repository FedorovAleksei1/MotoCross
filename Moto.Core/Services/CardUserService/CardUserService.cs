using AutoMapper;
using Moto.Domain.Dto;
using Moto.Domain.Models;
using MotoCross.Data;
using System;
using System.Linq;

namespace Moto.Core.Services.CardUserService
{
    public class CardUserService : ICardUserService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public CardUserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CardUserDto cardUser)
        {
            if(cardUser == null)
            {
                throw new Exception("Объект не может быть пустым");

            }

            var card = _mapper.Map<CardUser>(cardUser);
            _context.CardsUser.Add(card);
            _context.SaveChanges();
        }

        //public CardUserDto GetCardByUserId(string id)
        //{
        //   var carduser =  _context.Users.Where(x => x.Id == id );

        //}

        public CardUserDto GetCardUserById(int id)
        {
            var carduser =  _context.CardsUser.Where(o => o.Id == id).AsEnumerable();
            return _mapper.Map<CardUserDto>(carduser);
        }
    }
}
