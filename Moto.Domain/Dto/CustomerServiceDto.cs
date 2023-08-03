using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Dto
{
    public class CustomerServiceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вы не ввели имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вы не ввели цену")]
        public decimal Price { get; set; }

        public bool Individual { get; set; }
        public string BasePhoto64 { get; set; }

        public int? PhotoId { get; set; }

        public PhotoDto Photo { get; set; }

        public int OrderId { get; set; }

        public OrderDto Order { get; set; }
    }
}
