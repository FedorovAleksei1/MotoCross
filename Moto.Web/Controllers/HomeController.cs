﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moto.Core.Services.AdminService.AdminCardTeamUser;
using Moto.Core.Services.AdminService.AdminFormedTeam;
using Moto.Web.Areas.Admin.ViewModel;
using MotoCross.Services.InfoUserService;

namespace MotoCross.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserInfoService _userInfoService;
		private readonly ICardTeamUserService _cardTeamUserService;
		private readonly IFormedTeamService _formedTeamService;

        public HomeController(ILogger<HomeController> logger, IUserInfoService userInfoService, ICardTeamUserService cardTeamUserService, IFormedTeamService formedTeamService)
		{
			_logger = logger;
			_userInfoService = userInfoService;
			_cardTeamUserService = cardTeamUserService;
			_formedTeamService = formedTeamService;
		}

		//[Authorize(Roles = "admin")]
		public IActionResult Index()
		{
			var model = new MainViewModel();
			//var cardTeamUserDtos = _cardTeamUserService.AllCardTeam();
			//model.ItemCards = cardTeamUserDtos;

			return View(model);
		}

        public PartialViewResult CardPersonPartial( int page = 1, int take = int.MaxValue)
        {
            var model = new MainViewModel();
            var evetnPagination = _cardTeamUserService.AllCardTeam(page , take );
            model.ItemCards = evetnPagination;
            //model.MonthName = GetMonthName(month);
            return PartialView(model);
        }

		public PartialViewResult FormedTeamCard()
		{
			var model = new MainViewModel();
			var formedTeams = _formedTeamService.FormedTeams();
			model.FormedTeams = formedTeams;
			return PartialView(model);
        }

        public IActionResult Privacy()
		{
			return View();
		}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
