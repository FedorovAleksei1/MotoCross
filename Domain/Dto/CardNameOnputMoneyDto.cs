using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CardNameOnputMoneyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CardPutMoneyId { get; set; }
        public CardPutMoneyDto CardPutMoneyDto { get; set; } 
    }
}
