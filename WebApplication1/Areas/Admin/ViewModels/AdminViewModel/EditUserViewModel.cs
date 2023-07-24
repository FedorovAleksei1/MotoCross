using Domain.Dto;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Questionary.Web.Areas.Admin.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required][Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
        public string NewPassword { get; set; }
        public BalansDto Balans { get; set; }
        public decimal? NewPrice { get; set; }
    }
}
