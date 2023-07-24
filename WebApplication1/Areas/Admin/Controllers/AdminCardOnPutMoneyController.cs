using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Questionary.Core.Services.AdminService.AdminCardNamePutMoney;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminCardOnPutMoneyController : Controller
    {
        private readonly ICardNamePutMoneyService _cardNamePutMoneyService;
        public AdminCardOnPutMoneyController(ICardNamePutMoneyService cardNamePutMoneyService)
        {
            _cardNamePutMoneyService = cardNamePutMoneyService;
        }


        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new CardNameOnPutMoneyViewModel();
            var cards = _cardNamePutMoneyService.GetCardNameOnputMoney();
            model.cardsNameOnPutMoney = cards;
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CardNameOnPutMoneyViewModel();
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Create(CardNameOnPutMoneyViewModel model)
        {
            _cardNamePutMoneyService.Create(model.cardNameOnputMoneyDto);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var card = _cardNamePutMoneyService.CardNameOnputMoneyById(id);

            var model = new CardNameOnPutMoneyViewModel();
            model.cardNameOnputMoneyDto = card;
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(CardNameOnPutMoneyViewModel model)
        {
            _cardNamePutMoneyService.Edit(model.cardNameOnputMoneyDto);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _cardNamePutMoneyService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
