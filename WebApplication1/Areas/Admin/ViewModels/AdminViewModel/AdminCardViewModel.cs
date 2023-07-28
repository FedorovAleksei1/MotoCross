using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminCardViewModel
    {
        public  CardDto Card { get; set; }
        public IEnumerable<SelectListItem> CardsNameBanks { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
    }
}
