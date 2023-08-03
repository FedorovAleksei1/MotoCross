using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dto
{
    public class CardUserDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }

        public int CardId { get; set; }
        public CardDto Card { get; set; }
    }
}
