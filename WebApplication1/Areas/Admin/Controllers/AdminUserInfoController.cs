using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Questionary.Core.Services.AdminService.AdminEventService;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Core.Services.AdminService.AdminUserInfoService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminUserInfoController : Controller
    {
        private readonly IAdminUserInfoService _adminUserInfoService;
        public AdminUserInfoController(IAdminUserInfoService adminUserInfoService, IAdminImportantService adminImportantService)
        {
            _adminUserInfoService = adminUserInfoService;
            
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminUserInfoViewModel();
            var userinfoList = _adminUserInfoService.GetAll();
            model.PersonsTeam = userinfoList;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminUserInfoViewModel();

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
        public IActionResult Create(AdminUserInfoViewModel model)
        {
            _adminUserInfoService.CreateInfoUser(model.PersonInfoUser);

            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var item = _adminUserInfoService.GetByUserId(userId);
            var model = new AdminUserInfoViewModel();
            model.PersonInfoUser = item;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminUserInfoViewModel model)
        {
            _adminUserInfoService.EditInfoUSer(model.PersonInfoUser);

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _adminUserInfoService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
