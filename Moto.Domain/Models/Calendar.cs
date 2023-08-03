using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Calendar : BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string NameDay { get; set; }
        public string Importan { get; set; }
        public bool IsDeleted { get; set; }
    }
}
