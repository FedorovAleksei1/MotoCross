using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Models
{
    public class Photo : BaseEntity
    {
        public int Id { get; set; }

        public string NameFile { get; set; }

        //[Column(TypeName = "nvarchar(MAX)")]
        public byte[] Base64 { get; set; }
    }
}
