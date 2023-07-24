using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CardPutMoney
    {
        public int Id { get; set; }
        public decimal? PutMoneyOnCard { get; set; }
        
        public CardNameOnputMoney CardName { get; set; }
        //public string NameCardWriteUser { get; set; }
    }
}
