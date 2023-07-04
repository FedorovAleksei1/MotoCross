using Domain.Dto;
using Domain.Models;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Json;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;
using Questionary.Web.Areas.Admin.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoCross.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly IUserService _userService;
		private readonly SignInManager<User> _signInManager;
		private readonly IOrderService _orderService;

		public UserController(UserManager<User> userManager
			, IUserService userService
			, SignInManager<User> signInManager
			, IOrderService orderService)
		{
			_userService = userService;
			_userManager = userManager;
			_signInManager = signInManager;
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			var user = await _userService.GetUserByName(User.Identity.Name);
			var model = new UserViewModel();
			model.User = user;

			if (user.MotosDto == null || user.MotosDto.Count == 0)
			{
                List<MotoDto> motosDto = new List<MotoDto>();
                for (int i = 0; i < 3; i++)
                {
                    motosDto.Add(new MotoDto());
                }
                model.User.MotosDto = motosDto;
            }
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UserViewModel model)
		{
			await _userService.Edit(model.User);
			return RedirectToAction(nameof(Edit));
			// return RedirectToAction("Edit", "User", new { model.User.Id });
		}

		[HttpGet]
		public async Task<IActionResult> Orders()
		{
			var userName = User.Identity.Name;
			var orders = _orderService.GetOrder(userName);
			var model = new OrderViewModel(orders);
			return View(model);
		}

		[HttpPost]
		public IActionResult ConfirmationOrder(int orderId)
		{
			var response = new JsonResponse();
			var order = _orderService.GetById(orderId);
			var orderDto = new OrderDto();
			if (orderDto == null)
			{
				response.status = (int)JsonResponseStatuses.NotFound;
				response.message = "Объект не найден";
			}
			else
			{
				_orderService.Confirmation(order);
				response.status = (int)JsonResponseStatuses.Ok;
				response.message = "Заказ подвержден";
			}

			return Json(response);
		}

		[HttpGet]
		public async Task<PartialViewResult> GetPersonById(string id)
		{
			var user = await _userService.GetUserById(id);
			var model = new UserViewModel();
			model.User = user;
			return PartialView(model);
		}
	}
}