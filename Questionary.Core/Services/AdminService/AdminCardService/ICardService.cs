﻿using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminCardService
{
    public interface ICardService
    {
        IEnumerable<CardDto> GetAllCardAdmin();
        CardDto CardGetById(int id);
        void CreateCard(CardDto carddto);
        void EditCard(CardDto carddto);
        void DeleteCard(int id);
    }
}
