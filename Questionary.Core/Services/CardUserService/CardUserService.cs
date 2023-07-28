using AutoMapper;
using Domain.Dto;
using Domain.Models;
using MotoCross.Data;
using Questionary.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.CardUserService
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
