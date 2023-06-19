using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminUserInfoViewModel
    {
        public InfoUserDto PersonInfoUser { get; set; }
        public IEnumerable<InfoUserDto> PersonsTeam { get; set; }
    }
}
