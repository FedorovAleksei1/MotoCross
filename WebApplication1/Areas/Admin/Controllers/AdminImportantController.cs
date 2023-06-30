using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Questionary.Core.Services.AdminService.AdminEventService;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminImportantController : Controller
    {
        private readonly IAdminEventService _adminEventService;
        private readonly IAdminImportantService _adminImportantService;
        public AdminImportantController(IAdminEventService adminEventService, IAdminImportantService adminImportantService)
        {
            _adminEventService = adminEventService;
            _adminImportantService = adminImportantService;
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminImportantViewModel();
            var importantList = _adminImportantService.ListImportansDto();
            model.Importants = importantList;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminImportantViewModel();

            //var importantList = _adminImportantService.ListImportansDto().Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //}).ToList();

            //importantList.Insert(0, new SelectListItem
            //{
            //    Text = "--Не выбрано значение--",
            //    Value = 0.ToString()
            //});

            //model.ImportantsList = importantList;

            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Create(AdminImportantViewModel model )
        {
            _adminImportantService.CreateImportant(model.Important);

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _adminImportantService.GetImportanById(id);
            var model = new AdminImportantViewModel();
            model.Important = item;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminImportantViewModel model)
        {
            _adminImportantService.EditImportan(model.Important);

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _adminImportantService.DeleteImportan(id);

            return RedirectToAction("Index");
        }
    }
}
