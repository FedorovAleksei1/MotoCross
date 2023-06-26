using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminFormedTeamViewModel
    {
        public FormedTeamDto FormedTeam { get; set; }
        public IEnumerable<FormedTeamDto> ListFormedTeam { get; set; }
    }
}
