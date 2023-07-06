using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questionary.Core.Services.AdminService.AdminBalansService;
using Questionary.Core.Services.AdminService.AdminOperationService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Areas.Admin.Controllers
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
