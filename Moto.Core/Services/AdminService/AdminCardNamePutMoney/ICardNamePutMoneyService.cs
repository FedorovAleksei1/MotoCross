using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminCardNamePutMoney
{
    public interface ICardNamePutMoneyService
    {
        List<CardNameOnputMoneyDto> GetCardNameOnputMoney();
        CardNameOnputMoneyDto CardNameOnputMoneyById(int id);
        void Create(CardNameOnputMoneyDto cardNameOnputMoneyDto);
        void Edit(CardNameOnputMoneyDto cardNameOnputMoneyDto);
        void Delete(int id);
    }
}
