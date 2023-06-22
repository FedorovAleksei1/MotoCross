using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Questionary.Core.Services.AdminService.AdminCardTeamUser;
using Questionary.Core.Services.AdminService.AdminImportantService;
using Questionary.Core.Services.AdminService.AdminUserInfoService;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using System.Linq;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminCardTeamUserController : Controller
    {
        private readonly ICardTeamUserService _adminCardTeamUserService;
        public AdminCardTeamUserController(ICardTeamUserService adminCardTeamUserService)
        {
            _adminCardTeamUserService = adminCardTeamUserService;

        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminCardTeamUserViewModel();
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        public PartialViewResult AdminCardIndexInTable(int page = 1, int take = int.MaxValue)
        {
            var model = new AdminCardTeamUserViewModel();
            var userinfoList = _adminCardTeamUserService.AllCardTeam(page, take);
            model.CardPersonsTeam = userinfoList;

            return PartialView(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminCardTeamUserViewModel();

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
        public IActionResult Create(AdminCardTeamUserViewModel model)
        {
            _adminCardTeamUserService.CreateCardTeam(model.CardPerson, model.UploadPhoto);

            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _adminCardTeamUserService.GetByCardTeamId(id);
            var model = new AdminCardTeamUserViewModel();
            model.CardPerson = item;

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminCardTeamUserViewModel model)
        {
            _adminCardTeamUserService.EditCardTeam(model.CardPerson, model.UploadPhoto);

            return RedirectToAction("Index");
        }

		[Area("Admin")]
		[Authorize]
		[HttpGet]
		public IActionResult GetById(int id)
		{
			var item = _adminCardTeamUserService.GetByCardTeamId(id);
			var model = new AdminCardTeamUserViewModel();
			model.CardPerson = item;

			return View(model);
		}

		[Area("Admin")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _adminCardTeamUserService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

