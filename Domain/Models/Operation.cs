using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Operation : BaseEntity
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DictionaryTypeId { get; set; }
        public IEnumerable<OperationUser> OperationsUser { get; set; }
        
    }
}
