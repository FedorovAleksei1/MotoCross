using Microsoft.AspNetCore.Mvc;
using Questionary.Core.Services.AdminService.AdminCastomerService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Controllers
{
    public class CustomerServiceController : Controller
    {
        private readonly IAdminCustomerService _adminCustomerService;
        public CustomerServiceController(IAdminCustomerService adminCustomerService)
        {
            _adminCustomerService = adminCustomerService;
        }
        public IActionResult Index()
        {

            var model = new AdminCustomerServiceViewModel();
            var customer = _adminCustomerService.AllCustomerService();
            model.Customers = customer;
            return View(model);
        }
    }
}
