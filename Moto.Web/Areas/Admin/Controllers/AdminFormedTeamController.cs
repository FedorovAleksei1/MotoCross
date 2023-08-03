using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Core.Services.AdminService.AdminFormedTeam;
using Moto.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Moto.Web.Areas.Admin.Controllers
{
    public class AdminFormedTeamController : Controller
    {
        private readonly IFormedTeamService _formedTeamService;

        public AdminFormedTeamController(IFormedTeamService formedTeamService)
        {
            _formedTeamService=formedTeamService;
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminFormedTeamViewModel();
            var formedTeams = _formedTeamService.FormedTeams();
            model.ListFormedTeam = formedTeams;
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create() 
        {
            var model = new AdminFormedTeamViewModel();
            
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Create(AdminFormedTeamViewModel model)
        {
            _formedTeamService.CreateFormedTeam(model.FormedTeam);

            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _formedTeamService.GetFormedTeamBuId(id);
            var model = new AdminFormedTeamViewModel();
            model.FormedTeam = item;
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminFormedTeamViewModel model)
        {
            _formedTeamService.EditFormedTeam(model.FormedTeam);
            return RedirectToAction("Index");
        }

        public void Delete(int id) 
        {
            _formedTeamService.DeleteFormedTeam(id);
        }
    }
}
