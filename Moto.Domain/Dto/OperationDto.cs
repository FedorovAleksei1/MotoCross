using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dto
{
    public class OperationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DictionaryTypeId { get; set; }
        public IEnumerable<OperationUserDto> OperationsUser { get; set; }
    }
}
