using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminCardPutMoneyViewModel
    {
        public CardPutMoneyDto CardPutMoneyDto { get; set; }
        public IEnumerable<SelectListItem> CardsNameOnPutMoneyList { get; set; }
    }
}
