using Domain.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel.AdminViewModel
{
    public class AdminCardTeamUserViewModel
    {
        public IFormFile UploadPhoto { get; set; }
        public CardTeamUserDto CardPerson { get; set; }
        public PaginationDto<CardTeamUserDto> CardPersonsTeam { get; set; }
    }
}
