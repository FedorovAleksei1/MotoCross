using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Questionary.Core.Services.AdminService.AdminCardTeamUser
{
    public class CardTeamUserService : ICardTeamUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CardTeamUserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CardTeamUserDto> AllCardTeam()
        {
            var cardTeams = _context.CardTeamUsers.Include(x => x.Photo).Where(x => !x.IsDeleted).AsEnumerable();
            var cardTeamDto = _mapper.Map<IEnumerable<CardTeamUserDto>>(cardTeams);
            foreach (var card in cardTeamDto)
            {
                if (card.Photo != null && card.Photo.Base64 != null && card.Photo.Base64.Length > 0)
                {
                    string basePhoto64 = Convert.ToBase64String(card.Photo.Base64);
                    card.BasePhoto64 = $"data:image/png;base64,{basePhoto64}";
                }
            }
            return cardTeamDto;

        }

        public CardTeamUserDto GetByCardTeamId(int id)
        {
            var cardTeam = _context.CardTeamUsers.Include(x => x.Photo).FirstOrDefault(c => c.Id == id);
            var cardTeamDto = _mapper.Map<CardTeamUserDto>(cardTeam);
            return cardTeamDto;
        }

        public void CreateCardTeam(CardTeamUserDto cardTeamDto, IFormFile photo)
        {
            if (cardTeamDto == null)
                throw new Exception("Объект не может быть пустым");

            if (photo != null)
            {
                MemoryStream str = new();
                photo.CopyTo(str);

                var photoDto = new PhotoDto
                {
                    Base64 = str.ToArray(),
                    NameFile = photo.FileName
                };

                cardTeamDto.Photo = photoDto;

                var cardTeam = _mapper.Map<CardTeamUser>(cardTeamDto);

                _context.CardTeamUsers.Add(cardTeam);
                _context.SaveChanges();
            }
        }

        public void EditCardTeam(CardTeamUserDto cardTeamDto, IFormFile photo)
        {

            if (photo == null)
            {
                cardTeamDto.PhotoId = null;
            }
            if (photo != null)
            {
                MemoryStream str = new();
                photo.CopyTo(str);

                var photoDto = new PhotoDto
                {
                    Base64 = str.ToArray(),
                    NameFile = photo.FileName
                };

                cardTeamDto.Photo = photoDto;

                var cardTeam = _mapper.Map<CardTeamUser>(cardTeamDto);
                _context.Update(cardTeam);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                var cardTeam = _context.CardTeamUsers.Find(id);
                cardTeam.IsDeleted = true;
                _context.Update(cardTeam);
                _context.SaveChanges();
            }
        }
    }
}
