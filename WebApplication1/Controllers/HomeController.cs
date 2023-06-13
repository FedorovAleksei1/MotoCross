using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoCross.Models;
using MotoCross.Services.InfoUserService;
using Questionary.Web.Areas.Admin.VIewModel;
using System.Diagnostics;

namespace MotoCross.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserInfoService _userInfoService;

		public HomeController(ILogger<HomeController> logger, IUserInfoService userInfoService)
		{
			_logger = logger;
			_userInfoService = userInfoService;
		}

		//[Authorize(Roles = "admin")]
		public IActionResult Index()
		{
			var model = new MainViewModel();
			var inf = _userInfoService.GetAll();
			model.PersonsTeam = inf;

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
