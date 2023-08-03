using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Balans : BaseEntity
    {
        public int Id { get; set; }
        public DateTime DatePutMoney { get; set; }
        public int OperationId { get; set; }
        public decimal? BalansMoney { get; set; }
        public Operation Operation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
