﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Questionary.Web.Areas.Admin.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required][Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public string NewPassword { get; set; }
    }
}
