using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Questionary.Web.Areas.Admin.ViewModel.AdminViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required][Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
