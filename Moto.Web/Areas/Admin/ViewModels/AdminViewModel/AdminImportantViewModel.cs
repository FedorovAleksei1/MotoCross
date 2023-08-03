using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel.AdminViewModel
{
    public class AdminImportantViewModel
    {
        public int ImportantId { get; set; }
        public ImportantDto Important { get; set; }
        public IEnumerable<SelectListItem> ImportantsList { get; set; }
        public IEnumerable<ImportantDto> Importants { get; set; }
    }
}
