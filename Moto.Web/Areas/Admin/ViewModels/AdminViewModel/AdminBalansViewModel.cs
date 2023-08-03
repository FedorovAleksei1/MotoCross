using Moto.Domain.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModels.AdminViewModel
{
    public class AdminBalansViewModel
    {
        public BalansDto Balans { get; set; }
        public IEnumerable<SelectListItem> OperationsList { get; set; }
        public IEnumerable<BalansDto> ListBalans { get; set; }
    }
}
