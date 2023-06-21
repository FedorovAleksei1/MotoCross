using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Questionary.Core.Services.AdminService.AdminEventService;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminEventController : Controller
    {
        
        private readonly IAdminEventService _adminEventService;
        private readonly IAdminImportantService _adminImportantService;
        public AdminEventController(IAdminEventService adminEventService, IAdminImportantService adminImportantService)
        {
            _adminEventService = adminEventService;
            _adminImportantService = adminImportantService;
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminEventViewModel();
            var eventList = _adminEventService.ListAdminEventsDto();
            model.Events = eventList;

            return View(model);
           
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminEventViewModel();
            var importantselectlist = _adminImportantService.ListImportansDto()
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            importantselectlist.Insert(0, new SelectListItem
            {
                Text = "--Не выбрано значение--",
                Value = 0.ToString()
            });

            model.ImportantsList = importantselectlist;
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Create(AdminEventViewModel model)
        {
            _adminEventService.CreateAdminEvent(model.Event);

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _adminEventService.GetAdminEventById(id);
            var model = new AdminEventViewModel();
            var importantselectlist = _adminImportantService.ListImportansDto()
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            importantselectlist.Insert(0, new SelectListItem
            {
                Text = "--Не выбрано значение--",
                Value = 0.ToString()
            });

            model.ImportantsList = importantselectlist;
            model.Event = item;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminEventViewModel model)
        {
            _adminEventService.EditAdminEvent(model.Event);

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        
        public IActionResult Delete(int id)
        {
            _adminEventService.DeleteAdminEvent(id);

            return RedirectToAction("Index");
        }
    }
}
