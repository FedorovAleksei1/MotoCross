﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moto.Core.Services.AdminService.AdminBalansService;
using Moto.Core.Services.AdminService.AdminCardNamePutMoney;
using Moto.Core.Services.AdminService.AdminCardPutMoney;
using Moto.Core.Services.AdminService.AdminCardService;
using Moto.Core.Services.AdminService.AdminCastomerService;
using Moto.Core.Services.OperationUserService;
using Moto.Domain.Dto;
using Moto.Domain.Models;
using Moto.Domain.Models.ViewModel;
using Moto.Web.Areas.Admin.ViewModel;
using Moto.Web.Areas.Admin.ViewModels.AdminViewModel;
using MotoCross.Json;
using MotoCross.Services.CustomerServiceService;
using MotoCross.Services.MotoService;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;
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
        private readonly IMotoService _motoService;
        private readonly IAdminCustomerService _adminCustomerService;
        private readonly ICustomerServiceService _customerServiceService;
        private readonly ICardPutMoneyService _cardPutMoneyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICardService _cardService;
        private readonly ICardNamePutMoneyService _cardNamePutMoneyService;

        public UserController(UserManager<User> userManager
            , IUserService userService
            , SignInManager<User> signInManager
            , IOrderService orderService
            , IBalansService balansService
            , IOperationUserService operationUserService
            , IMapper mapper
            , IMotoService motoService
            , IAdminCustomerService adminCustomerService
            , ICustomerServiceService customerServiceService
            , ICardPutMoneyService cardPutMoneyService
            , IHttpContextAccessor httpContextAccessor
            , ICardService cardService
            , ICardNamePutMoneyService cardNamePutMoneyService)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;
            _balansService = balansService;
            _operationUserService = operationUserService;
            _mapper = mapper;
            _motoService = motoService;
            _adminCustomerService = adminCustomerService;
            _customerServiceService = customerServiceService;
            _cardPutMoneyService = cardPutMoneyService;
            _httpContextAccessor = httpContextAccessor;
            _cardService = cardService;
            _cardNamePutMoneyService = cardNamePutMoneyService;
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
        public async Task<IActionResult> Orders(int page, int take)
        {
            var userName = User.Identity.Name;
            var orders = _orderService.GetOrder(userName, page, take);
            var username = await _userService.GetUserByName(User.Identity.Name);
            var model = new AdminOrderViewModel(orders);
            model.User = username;
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UserOrders()
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
        public IActionResult ResetTranzaction(int orderId)
        {
            var response = new JsonResponse();
            var order = _orderService.GetById(orderId);
            var balans = _userService.GetUserByName(order.UserId);
            //var orderDto = _mapper.Map<OrderDto>(order);
            UserViewModel model = new();
            var userBalans = _balansService.GetBalansByUserId(order.UserId);
           
            if (userBalans == null)
            {
                //model.Balans = new();
                _balansService.CreateBalans(new BalansDto()
                {
                    UserId = order.UserId,
                    OperationId = 2
                });

                userBalans = _balansService.GetBalansByUserId(order.UserId);
            }

            if (userBalans?.BalansMoney < order?.Price || userBalans?.BalansMoney == null)
            {
                response.status = (int)JsonResponseStatuses.NotPrice;
                response.message = "Суммы недостаточно, пополните баланс";
            }
            else
            {
                if (order == null)
                {
                    response.status = (int)JsonResponseStatuses.NotFound;
                    response.message = "Объект не найден";
                }
                else
                {
                    _operationUserService.ListOperationsUser(order.UserId);
                    _orderService.Confirmation(order);
                    response.status = (int)JsonResponseStatuses.Ok;
                    response.message = "Заказ подвержден";
                }
                var operation = new OperationUserDto()
                {
                    OrderId = orderId,
                    //Order = orderDto,
                    UserId = order.UserId,
                    Price = (decimal)order.Price,
                    DataOperation = DateTime.Now

                };
                _operationUserService.ResetBalans(operation);
            }


            
            //var balansuser = new BalansDto()
            //{
            //	DatePutMoney = DateTime.Now,
            //	//BalansMoney =
            //             Operation.Name = balans.
            //         }


            
            return Json(response);
        }


        public IActionResult DeleteMoto(int id)
        {
            _motoService.Delete(id);
            return RedirectToAction("Edit");

        }

        [HttpGet]
        public async Task<PartialViewResult> CardPushMoney()
        {

            var model = new CardNameOnPutMoneyViewModel();
            var user = await _userService.GetUserByName(User.Identity.Name);

            var cardList = _cardService.GetAllCardAdmin().Select(i => new SelectListItem
            {
                Text = i.CardNumber,
                Value = i.Id.ToString()
            }).ToList();

            cardList.Insert(0, new SelectListItem
            {
                Text = "--Не выбрано значение--",
                Value = 0.ToString()
            });

            model.BankCards = cardList;
            model.CardNameOnputMoneyDto = new CardNameOnputMoneyDto();
            model.CardNameOnputMoneyDto.UserId =  user.Id;


            //var model = new AdminCardPutMoneyViewModel();
            //var card = _cardPutMoneyService.EditCardPutMoney();
            //model.CardPutMoneyDto = card;
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult CardPushMoney(CardNameOnPutMoneyViewModel model)
        {
            //if (model.CardNameOnputMoneyDto.CardId == 0)
            //    return RedirectToAction(nameof(Edit));

            if (model.CardNameOnputMoneyDto.CardId != 0)
            {
                _cardNamePutMoneyService.Create(model.CardNameOnputMoneyDto);
                //await _userService.Edit(model.User);
            }

            return RedirectToAction(nameof(Edit));
        }

        public PartialViewResult AdminComentInCustomer(int id)
        {
            var item = _orderService.GetById(id);
            var model = new OrderViewModel();
            model.Order = item;

            return PartialView(model);
        }


        public async Task<IActionResult> Index()
        {

            var model = new AdminCustomerServiceViewModel();
            var customer = _adminCustomerService.AllCustomerService();
            var username = await _userService.GetUserByName(User.Identity.Name);
            model.User = username;
            model.Customers = customer;
            return View(model);
        }



        [HttpPost]
        public IActionResult Addorder(int customerId)
        {
            HttpContext context = _httpContextAccessor.HttpContext;

            string username = "";
            // Проверка, авторизован ли пользователь
            if (context.User.Identity.IsAuthenticated)
            {
                // Получение имени пользователя
                username = context.User.Identity.Name;

                // Дополнительные действия с авторизованным пользователем
                // ...
            }
            var response = new JsonResponse();

            if (!string.IsNullOrEmpty(username))
            {
                var customer = _adminCustomerService.GetCustomerServiceById(customerId);

                if (customer == null)
                {
                    response.status = (int)JsonResponseStatuses.NotFound;
                    response.message = "Объект не найден";
                }
                else
                {
                    _customerServiceService.AddInOrders(customer, username);
                    response.status = (int)JsonResponseStatuses.Ok;
                    response.message = "Заказ подвержден";
                }
            }
            else
            {
                response.status = (int)JsonResponseStatuses.NotFound;
                response.message = "Объект не существует";
            }


            return Json(response);
        }
    }
}