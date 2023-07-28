using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.CardUserService
{
    public interface ICardUserService
    {
        //CardUserDto GetCardByUserId(string id);
        CardUserDto GetCardUserById(int id);

        void Create (CardUserDto cardUser);
    }
}
