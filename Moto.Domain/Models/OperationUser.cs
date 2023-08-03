using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class OperationUser : BaseEntity
    {
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public DateTime DataOperation { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
    }
}
