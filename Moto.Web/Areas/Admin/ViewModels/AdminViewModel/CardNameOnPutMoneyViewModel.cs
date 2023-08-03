using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class CardNameOnPutMoneyViewModel
    {
        public CardNameOnputMoneyDto CardNameOnputMoneyDto { get; set; }
        public IEnumerable<SelectListItem> BankCards { get; set; }

        public List<CardNameOnputMoneyDto> CardsNameOnPutMoney { get; set; } = new();

       // public Dictionary<User, > MyProperty { get; set; }
        public UserDto User { get; set; }
        

        //public UserDto User { get; set; }
    }
}
