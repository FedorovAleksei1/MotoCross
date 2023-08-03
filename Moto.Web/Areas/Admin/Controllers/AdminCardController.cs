using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moto.Core.Services.AdminService.AdminCardService;
using Moto.Core.Services.CardUserService;
using Moto.Domain.Dto;
using Moto.Web.Areas.Admin.ViewModels.AdminViewModel;
using MotoCross.Services.UserService;
using System.Threading.Tasks;

namespace Moto.Web.Areas.Admin.Controllers
{
    public class AdminCardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IUserService _userService;
        private readonly ICardUserService _cardUserService;
        public AdminCardController(ICardService cardService, IUserService userService, ICardUserService cardUserService)
        {
            _cardService = cardService;
            _userService = userService;
            _cardUserService = cardUserService;
        }


        [Area("Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var model = new AdminCardViewModel();
            var cards = _cardService.GetAllCardAdmin();
            model.Cards = cards;
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdminCardViewModel();

            //var importantList = Enum.GetNames(typeof(NameNanks));            

            //var c = importantList.Cast<NameNanks>().Select(i => new SelectListItem()
            //{
            //    Text = i.ToString(),
            //    Value = i.ToString()
            //}).ToList();

            
            //model.CardsNameBanks = new SelectList(c, "Value", "Text");

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public async Task< IActionResult> Create(AdminCardViewModel model)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);

            var cardUser = new CardUserDto()
            {
                Card = model.Card,
                UserId = user.Id 
            };

            
            //_cardService.CreateCard(model.Card);
            _cardUserService.Create(cardUser);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var card = _cardService.CardGetById(id);

            var model = new AdminCardViewModel();
            model.Card = card;
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public IActionResult Edit(AdminCardViewModel model)
        {
            _cardService.EditCard(model.Card);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _cardService.DeleteCard(id);
            return RedirectToAction("Index");
        }
    }
}
