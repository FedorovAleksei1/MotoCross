using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModel
{
    public class MainViewModel
    {
        public IEnumerable<CardTeamUserDto> CardTeamUserDtos { get; set; }
        public IEnumerable<InfoUserDto> PersonsTeam { get; set; }
		public PaginationDto<CardTeamUserDto> ItemCards { get; set; }
	}
}
