using Moto.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminBalansService
{
    public interface IBalansService
    {

        IEnumerable<BalansDto> GetAllBalans();

        BalansDto GetBalansByUserId(string id);

        void CreateBalans(BalansDto balansDto);
        void EditBalans(BalansDto balansDto);
    }
}
