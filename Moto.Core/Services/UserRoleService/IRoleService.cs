using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.UserRoleService
{
    public interface IRoleService
    {
        string GetRoleByUserId (string userId);
    }
}
