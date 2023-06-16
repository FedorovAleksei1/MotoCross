using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoCross.Models;
using MotoCross.Services.InfoUserService;
using Questionary.Core.Services.AdminService.AdminCardTeamUser;
using Questionary.Web.Areas.Admin.VIewModel;
using System.Diagnostics;

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
			var cardTeamUserDtos = _cardTeamUserService.AllCardTeam();
			model.CardTeamUserDtos = cardTeamUserDtos;

			return View(model);
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
