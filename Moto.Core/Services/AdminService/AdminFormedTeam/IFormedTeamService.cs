using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminFormedTeam
{
    public interface IFormedTeamService
    {

        IEnumerable<FormedTeamDto> FormedTeams();
        FormedTeamDto GetFormedTeamBuId (int id);
        void CreateFormedTeam (FormedTeamDto formedTeam);
        void EditFormedTeam (FormedTeamDto formedTeam);
        void DeleteFormedTeam (int id);
    }
}
