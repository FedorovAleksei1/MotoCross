using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class BalansDto
    {
        public int Id { get; set; }
        public string BalansMoney { get; set; }
        public DateTime DatePutMoney { get; set; }
        public OperationDto Operation { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
