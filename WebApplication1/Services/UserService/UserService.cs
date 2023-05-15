using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MotoCross.Data;
using MotoCross.Dto;
using MotoCross.Models;
using MotoCross.Services.MotoService;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace MotoCross.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IMotoService _motoService;
        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, IMotoService motoService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _motoService = motoService;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id должен быть больше 0");

            var user = await _userManager.FindByIdAsync(id);


            if (user == null)
                throw new Exception("Объект не найден");

            var userdto = _mapper.Map<UserDto>(user);
         
            return userdto;
        }
        public async Task<UserDto> GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("name должен быть больше 0");

            var user = await _userManager.FindByNameAsync(name);


            if (user == null)
                throw new Exception("Объект не найден");

            var userdto = _mapper.Map<UserDto>(user);
         
            return userdto;
        }

        public async Task Edit(UserDto userdto)
        {
            if (userdto == null)
                throw new Exception("Объект не может быть пустым");

            if (string.IsNullOrEmpty(userdto.FirstName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(userdto.MiddleName))
                throw new Exception("Наименование не может быть пустым");

            if (string.IsNullOrEmpty(userdto.LastName))
                throw new Exception("Наименование не может быть пустым");

            var user = await _userManager.FindByIdAsync(userdto.Id);

            //var user = _mapper.Map<User>(userdto);

            //user.UserName = $"{user.LastName} {user.FirstName} {user.MiddleName}";
            user.UserName = userdto.Email;
            user.Email = userdto.Email;
            user.FirstName = userdto.FirstName;
            user.MiddleName = userdto.MiddleName;
            user.LastName = userdto.LastName;
            user.Phone = userdto.Phone;


            IdentityResult result = await _userManager.UpdateAsync(user);

            //userdto.MotosDto.ForEach(p => p.UserId = user.Id);
            //_motoService.Create(userdto.MotosDto);
        }     
    }
}
