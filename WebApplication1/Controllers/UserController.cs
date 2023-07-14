using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Json;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;
using Questionary.Core.Services.AdminService.AdminBalansService;
using Questionary.Core.Services.OperationUserService;
using Questionary.Web.Areas.Admin.ViewModel;
using System;
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
		private readonly IBalansService _balansService;
		private readonly IOperationUserService _operationUserService;
		private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager
			, IUserService userService
			, SignInManager<User> signInManager
			, IOrderService orderService
			, IBalansService balansService
			, IOperationUserService operationUserService
			, IMapper mapper)
		{
			_userService = userService;
			_userManager = userManager;
			_signInManager = signInManager;
			_orderService = orderService;
			_balansService = balansService;
			_operationUserService = operationUserService;
			_mapper = mapper;
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
            var username = await _userService.GetUserByName(User.Identity.Name);
            var model = new OrderViewModel(orders);
			model.User = username;
			return View(model);
		}

		//[HttpPost]
		//public IActionResult ConfirmationOrder(int orderId)
		//{
		//	var response = new JsonResponse();
		//	var order = _orderService.GetById(orderId);
		//	var orderDto = new OrderDto();
		//	if (orderDto == null)
		//	{
		//		response.status = (int)JsonResponseStatuses.NotFound;
		//		response.message = "Объект не найден";
		//	}
		//	else
		//	{
		//		_orderService.Confirmation(order);
		//		response.status = (int)JsonResponseStatuses.Ok;
		//		response.message = "Заказ подвержден";
		//	}

		//	return Json(response);
		//}

		[HttpGet]
		public async Task<PartialViewResult> GetPersonById(string id)
		{
			var user = await _userService.GetUserById(id);
			var model = new UserViewModel();
			model.User = user;
			return PartialView(model);
		}

        [HttpGet]
        public async Task<IActionResult> GetBalansByUserId(string id)
		{
            //var userBalans = _balansService.GetBalansByUserId(id);
            //         var username = await _userService.GetUserByName(User.Identity.Name);
            //         var model = new UserViewModel();
            //if(userBalans == null)
            //{
            //	model.Balans = new();
            //}
            //else
            //{
            //	model.Balans = userBalans;
            //}

            //model.User = username;
            //         return View(model);


			UserViewModel model = new();


            var userBalans = _balansService.GetBalansByUserId(id);

            if (userBalans == null)
            {
                model.Balans = new();
            }
            else
            {
                model.Balans = userBalans;
            }

            var username = await _userService.GetUserByName(User.Identity.Name);
            model.User = username;

            model.OpeartionUser = _operationUserService.ListOperationsUser(id).ToList();

			return View(model);
        }
        [HttpPost]
        public void AddTranzaction(OrderViewModel model, int orderId) 
		{
			var operation = model.User.OperationsUser.FirstOrDefault(o => o.OrderId == orderId);
			//var operation = new OperationDto() { };

            _operationUserService.AddBalans(operation);

        }

        [HttpPost]
        public IActionResult ResetTranzaction(int orderId, string UserId)
        {
            var response = new JsonResponse();
            var order = _orderService.GetById(orderId);
			var balans = _userService.GetUserByName(UserId);
			//var orderDto = _mapper.Map<OrderDto>(order);
			
			if (order == null)
            {
                response.status = (int)JsonResponseStatuses.NotFound;
                response.message = "Объект не найден";
            }
            else
            {
				_operationUserService.ListOperationsUser(UserId);
                _orderService.Confirmation(order);
                response.status = (int)JsonResponseStatuses.Ok;
                response.message = "Заказ подвержден";
            }
            var operation = new OperationUserDto() {
				OrderId = orderId,
				//Order = orderDto,
				UserId = order.UserId,
				Price = order.Price,
				DataOperation = DateTime.Now
				
			};
			//var balansuser = new BalansDto()
			//{
			//	DatePutMoney = DateTime.Now,
			//	//BalansMoney =
   //             Operation.Name = balans.
   //         }


            _operationUserService.ResetBalans(operation);
			return Json(response);
        }

        public PartialViewResult CardPushMoney()
        {
            
            return PartialView();
        }
    }
}