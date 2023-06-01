using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CategoryClouth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Сloth> Cloths { get; set; }
    }
}
