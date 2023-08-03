using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Web.Areas.Admin.ViewModels.AdminViewModel;
using Moto.Core.Services.AdminService.AdminBalansService;
using Moto.Core.Services.AdminService.AdminOperationService;

namespace Moto.Web.Areas.Admin.Controllers
{
    public class AdminBalansController : Controller
    {
        private readonly IBalansService _balansService;
        private readonly IOperationService _operationService;
        public AdminBalansController(IBalansService balansService, IOperationService operationService)
        {
            _balansService = balansService;
            _operationService = operationService;

        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminBalansViewModel();
            model.ListBalans = _balansService.GetAllBalans();
            
            return View(model);
        }

    }
}
