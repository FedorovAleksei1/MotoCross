using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CardPutMoneyDto
    {
        public int Id { get; set; }
        public decimal? PutMoneyOnCard { get; set; }

        public CardNameOnputMoneyDto CardName { get; set; }
    }
}
