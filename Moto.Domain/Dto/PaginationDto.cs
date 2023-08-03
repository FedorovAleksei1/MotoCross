using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dto
{
    public class PaginationDto<T>
    {
        public List<T> Elements { get; set; } = new();
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
