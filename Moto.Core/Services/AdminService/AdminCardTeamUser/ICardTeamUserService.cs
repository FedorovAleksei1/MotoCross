using Domain.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminCardTeamUser
{
    public interface ICardTeamUserService
    {
        CardTeamUserDto GetByCardTeamId(int id);
       
        PaginationDto<CardTeamUserDto> AllCardTeam(int page, int take);
		void CreateCardTeam(CardTeamUserDto cardTeamDto, IFormFile photo);
        void EditCardTeam(CardTeamUserDto cardTeamDto, IFormFile photo);
        void Delete(int id);
    }
}
