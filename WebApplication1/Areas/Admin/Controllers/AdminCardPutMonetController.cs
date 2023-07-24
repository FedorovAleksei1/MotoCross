using Microsoft.AspNetCore.Mvc;
using Questionary.Core.Services.AdminService.AdminCardPutMoney;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminCardPutMonetController : Controller
    {
        private readonly ICardPutMoneyService _cardPutMoneyService;
        public AdminCardPutMonetController(ICardPutMoneyService cardPutMoneyService)
        {
            _cardPutMoneyService = cardPutMoneyService;
        }
        public IActionResult Index()
        {
            var model = new AdminCardPutMoneyViewModel();
            return View(model);
        }
    }
}
