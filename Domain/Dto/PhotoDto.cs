using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PhotoDto : BaseEntity
    {
        public int Id { get; set; }

        public string NameFile { get; set; }

        public byte[] Base64 { get; set; }
    }
}
