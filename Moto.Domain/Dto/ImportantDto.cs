using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dto
{
    public class ImportantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
