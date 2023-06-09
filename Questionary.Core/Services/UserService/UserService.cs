using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using MotoCross.Data;
using MotoCross.Models;
using MotoCross.Services.InfoUserService;
using MotoCross.Services.MotoService;
using System;
using System.Collections.Generic;
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
        private readonly IUserInfoService _userInfoService;
		public UserService(ApplicationDbContext context
            , IMapper mapper
            , UserManager<User> userManager
            , IMotoService motoService
            , IUserInfoService userInfoService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _motoService = motoService;
            _userInfoService = userInfoService;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id не должен быть пустым");

            var user = await _userManager.FindByIdAsync(id);

            var motos = _motoService.GetAllByUserId(user.Id);
            var info = _userInfoService.GetByUserId(user.Id);

			if (user == null)
                throw new Exception("Объект не найден");

            var userdto = _mapper.Map<UserDto>(user);
            userdto.MotosDto = motos;
            userdto.InfoDto = info;
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

			if (!string.IsNullOrEmpty(userdto.MotoName))
			{
                var moto = new MotoDto
                {
                    UserId = user.Id,
                    Name = userdto.MotoName
                };
				var listMoto = new List<MotoDto>
				{
					moto
				};

				_motoService.Create(listMoto);
			}

			//foreach (var item in userdto.MotosDto)
   //         {
   //             item.UserId = user.Id;
   //         }
            //_motoService.Create(userdto.MotosDto);
        }     
    }
}
