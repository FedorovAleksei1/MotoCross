using Domain.Dto;
using Domain.Models;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class CardNameOnPutMoneyViewModel
    {
        public CardNameOnputMoneyDto cardNameOnputMoneyDto { get; set; }
        public List<CardNameOnputMoneyDto>cardsNameOnPutMoney { get; set; }
    }
}
