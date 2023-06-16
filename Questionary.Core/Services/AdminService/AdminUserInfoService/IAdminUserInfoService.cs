using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminUserInfoService
{
    public interface IAdminUserInfoService
    {
        InfoUserDto GetByUserId(string userId);
        //void CreateInfoUser (InfoUserDto infoUser)
        IEnumerable<InfoUserDto> GetAll();
        void CreateInfoUser (InfoUserDto infoUser);
        void EditInfoUSer (InfoUserDto infoUser);
        void Delete(int id);
    }
}
