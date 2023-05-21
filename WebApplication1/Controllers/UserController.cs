using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Dto;
using MotoCross.Json;
using MotoCross.Models;
using MotoCross.Models.VIewModel;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;
using System;
using System.Security.Claims;
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
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            await _userService.Edit(model.User);
            return RedirectToAction("Index", "Home");
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
    }
}