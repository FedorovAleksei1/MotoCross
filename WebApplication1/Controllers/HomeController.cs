using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoCross.Models;
using MotoCross.Services.InfoUserService;
using Questionary.Core.Services.AdminService.AdminCardTeamUser;
using Questionary.Web.Areas.Admin.ViewModel;
using System.Diagnostics;
using System.Linq;

namespace MotoCross.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserInfoService _userInfoService;
		private readonly ICardTeamUserService _cardTeamUserService;

        public HomeController(ILogger<HomeController> logger, IUserInfoService userInfoService, ICardTeamUserService cardTeamUserService)
		{
			_logger = logger;
			_userInfoService = userInfoService;
			_cardTeamUserService = cardTeamUserService;
		}

		//[Authorize(Roles = "admin")]
		public IActionResult Index()
		{
			var model = new MainViewModel();
			//var cardTeamUserDtos = _cardTeamUserService.AllCardTeam();
			//model.ItemCards = cardTeamUserDtos;

			return View(model);
		}

        public PartialViewResult CardPersonPartial( int page = 1, int take = 1000)
        {
            var model = new MainViewModel();
            var evetnPagination = _cardTeamUserService.AllCardTeam(page , take );
            model.ItemCards = evetnPagination;
            //model.MonthName = GetMonthName(month);
            return PartialView(model);
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
