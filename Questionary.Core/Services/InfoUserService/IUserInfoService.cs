using Domain.Dto;
using System.Collections.Generic;

namespace MotoCross.Services.InfoUserService
{
    public interface IUserInfoService
    {
		InfoUserDto GetByUserId(string userId);
		//void CreateInfoUser (InfoUserDto infoUser)
		IEnumerable<InfoUserDto> GetAll();
    }
}
