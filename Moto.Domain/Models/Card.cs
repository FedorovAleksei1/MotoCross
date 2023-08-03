using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Card : BaseEntity
    {
        public int Id { get; set; }

        public string CardType { get; set; }
        public string CardNumber { get; set; }
        //public int CardUserId {get; set; }

        public List<CardNameOnputMoney> CardNameOnputMoneys { get; set; }
    }
}
