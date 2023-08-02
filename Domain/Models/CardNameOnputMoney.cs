using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CardNameOnputMoney : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
