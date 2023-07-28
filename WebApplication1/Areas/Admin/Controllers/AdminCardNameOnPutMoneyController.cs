using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.UserService;
using Questionary.Core.Services.AdminService.AdminCardNamePutMoney;
using Questionary.Core.Services.AdminService.AdminCardService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminCardNameOnPutMoneyController : Controller
    {
        private readonly ICardNamePutMoneyService _cardNamePutMoneyService;
        private readonly IUserService _userService;
        public AdminCardNameOnPutMoneyController(ICardNamePutMoneyService cardNamePutMoneyService, IUserService userService)
        {
            _cardNamePutMoneyService = cardNamePutMoneyService;
            _userService = userService;
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            //var user = 
            var cards = _cardNamePutMoneyService.GetCardNameOnputMoney();
            var model = new CardNameOnPutMoneyViewModel();
            model.CardsNameOnPutMoney = cards;

            return View(model);
        }
    }
}
