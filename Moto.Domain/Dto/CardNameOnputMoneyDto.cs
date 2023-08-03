using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Moto.Domain.Dto
{
    public class CardNameOnputMoneyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} is required.")]
        public decimal Price { get; set; }

        [Display(Name = "CardId")]
        [Required(ErrorMessage = "{0} is required.")]
        public int CardId { get; set; }
        public CardDto Card { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
