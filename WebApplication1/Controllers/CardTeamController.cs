using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questionary.Core.Services.AdminService.AdminCardTeamUser;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;

namespace Questionary.Web.Controllers
{
    public class CardTeamController : Controller
    {
        private readonly ICardTeamUserService _adminCardTeamUserService;
        public CardTeamController(ICardTeamUserService adminCardTeamUserService)
        {
            _adminCardTeamUserService = adminCardTeamUserService;

        }

       
        public IActionResult Index()
        {
            var model = new AdminCardTeamUserViewModel();
            var userinfoList = _adminCardTeamUserService.AllCardTeam();
            model.CardPersonsTeam = userinfoList;

            return View(model);
        }

        
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
       
        [HttpPost]
        public IActionResult Create(AdminCardTeamUserViewModel model)
        {
            _adminCardTeamUserService.CreateCardTeam(model.CardPerson, model.UploadPhoto);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _adminCardTeamUserService.GetByCardTeamId(id);
            var model = new AdminCardTeamUserViewModel();
            model.CardPerson = item;

            return View(model);
        }

        
        [HttpPost]
        public IActionResult Edit(AdminCardTeamUserViewModel model)
        {
            _adminCardTeamUserService.EditCardTeam(model.CardPerson, model.UploadPhoto);

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public PartialViewResult GetById(int id)
        {
            var item = _adminCardTeamUserService.GetByCardTeamId(id);
            var model = new AdminCardTeamUserViewModel();
            model.CardPerson = item;

            return PartialView(model);
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _adminCardTeamUserService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
