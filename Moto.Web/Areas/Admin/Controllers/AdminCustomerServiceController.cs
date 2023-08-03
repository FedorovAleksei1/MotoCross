using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Core.Services.AdminService.AdminCastomerService;
using Moto.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Moto.Web.Areas.Admin.Controllers
{
    public class AdminCustomerServiceController : Controller
    {
        private readonly IAdminCustomerService _adminCustomerService;
        public AdminCustomerServiceController(IAdminCustomerService adminCustomerService)
        {
            _adminCustomerService = adminCustomerService;
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminCustomerServiceViewModel();
            var customerList = _adminCustomerService.AllCustomerService();
            model.Customers = customerList;
            return View(model);

        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminCustomerServiceViewModel();
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Create(AdminCustomerServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                _adminCustomerService.CreateCustomerService(model.Customer);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _adminCustomerService.GetCustomerServiceById(id);
            var model = new AdminCustomerServiceViewModel();
            model.Customer = customer;
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminCustomerServiceViewModel model)
        {
            _adminCustomerService.EditCustomerService(model.Customer, model.UploadPhoto);
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _adminCustomerService.DeleteCustomerService(id);
            return RedirectToAction("Index");
        }
    }
}
