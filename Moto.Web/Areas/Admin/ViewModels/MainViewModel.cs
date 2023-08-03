using Moto.Domain.Dto;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel
{
    public class MainViewModel
    {
        public IEnumerable<CardTeamUserDto> CardTeamUserDtos { get; set; }
        public IEnumerable<InfoUserDto> PersonsTeam { get; set; }
        public IEnumerable<FormedTeamDto> FormedTeams { get; set; }      
        public PaginationDto<CardTeamUserDto> ItemCards { get; set; }
	}
}
