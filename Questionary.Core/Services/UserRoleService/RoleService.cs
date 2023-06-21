using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotoCross.Data;
using Questionary.Core.Services.ImportantService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.UserRoleService
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly  ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
            
        }
        public string GetRoleByUserId(string userId)
        {
            var rol = _context.UserRoles.FirstOrDefault(x => x.UserId == userId);
            
            if (rol != null)
            {
                var roleName = _context.Roles.FirstOrDefault(x => x.Id == rol.RoleId).Name;
                return roleName;
            }
            return null;
        }
    }
}
