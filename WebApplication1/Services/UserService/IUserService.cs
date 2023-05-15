using MotoCross.Dto;
using System;
using System.Threading.Tasks;

namespace MotoCross.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(string id);
        Task<UserDto> GetUserByName(string name);
        Task Edit(UserDto userdto);
    }
}
