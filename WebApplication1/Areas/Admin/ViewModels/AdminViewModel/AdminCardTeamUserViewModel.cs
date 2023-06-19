using Domain.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModel.AdminViewModel
{
    public class AdminCardTeamUserViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public CardTeamUserDto CardPerson { get; set; }
        public IEnumerable<CardTeamUserDto> CardPersonsTeam { get; set; }
    }
}
