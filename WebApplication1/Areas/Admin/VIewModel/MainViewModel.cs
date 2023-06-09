using Domain.Dto;
using System.Collections.Generic;

namespace Questionary.Web.Areas.Admin.VIewModel
{
    public class MainViewModel
    {
        public IEnumerable<InfoUserDto> PersonsTeam { get; set; }
    }
}
