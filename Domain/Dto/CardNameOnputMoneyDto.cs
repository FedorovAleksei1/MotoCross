﻿using Domain.Models;
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
        public decimal Price { get; set; }

        public int CardId { get; set; }
        public CardDto Card { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
