using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.UserService;
using System.Threading.Tasks;
using System;
using System.Linq;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Questionary.Web.Areas.Admin.ViewModels;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;
using AutoMapper;
using Questionary.Core.Services.UserRoleService;
using System.Collections;
using System.Collections.Generic;
using Domain.Models.ViewModel;
using MotoCross.Services.OrderService;
using Domain.Dto;
using MotoCross.Json;
using Questionary.Core.Services.AdminService.AdminBalansService;
using Questionary.Core.Services.OperationUserService;
using Questionary.Core.Services.AdminService.AdminCastomerService;
using MotoCross.Services.CustomerServiceService;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        //private readonly IUserRoleStore<User> _userRoleStore;
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IOrderService _orderService;
        private readonly IBalansService _balansService;
        private readonly IOperationUserService _operationUserService;
        private readonly IAdminCustomerService _adminCustomerService;



        public AdminUserController(UserManager<User> userManager, IUserService userService, /*IUserRoleStore<User> userRoleStore,*/ IMapper mapper, RoleManager<IdentityRole> roleManager, IRoleService roleService, IOrderService orderService, IBalansService balansService, IOperationUserService operationUserService, IAdminCustomerService adminCustomerService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            //_userRoleStore = userRoleStore;
            _roleManager = roleManager;
            _roleService = roleService;
            _orderService = orderService;
            _balansService = balansService;
            _operationUserService = operationUserService;
            _adminCustomerService = adminCustomerService;
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult Index(string searchBy, string searchTerm)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "" });

            List<UserRoleViewModel> userRoles = new();
            var data = _userManager.Users.ToList();

            foreach (var item in data)
            {
                var role = _roleService.GetRoleByUserId(item.Id);

                userRoles.Add(new() { User = item, Role = role });
            }

            if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchTerm))
            {
                switch (searchBy)
                {
                    case "Email":
                        userRoles = userRoles.Where(p => !string.IsNullOrEmpty(p.User.Email) && p.User.Email.StartsWith(searchTerm)).OrderBy(p => p.User.Email).ToList();
                        break;
                    case "Phone":
                        userRoles = userRoles.Where(p => !string.IsNullOrEmpty(p.User.Phone) && p.User.Phone.Contains(searchTerm)).OrderBy(p => p.User.Phone).ToList();
                        break;
                    default:
                        break;
                }
            }

            return View(userRoles.OrderBy(x => x.User.Id).ToList());
        }

        [Area("Admin")]
        [Authorize]
        public IActionResult Create()
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            return View();
        }






        [Area("Admin")]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            var user = await _userManager.FindByIdAsync(id);
            var balans = _balansService.GetBalansByUserId(user.Id);
            if (user == null)
                return NotFound();


            var model = new EditUserViewModel { Id = user.Id, Email = user.Email, Phone = user.Phone };
            model.Balans = balans;
            return View(model);
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);
            _balansService.EditBalans(model.Balans);
            if (user == null) return View(model);

            user.Email = model.Email;
            user.UserName = model.Email;
            user.Phone = model.Phone;


            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                var passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as
                        IPasswordValidator<User>;
                var passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as
                        IPasswordHasher<User>;

                var result1 = await passwordValidator?.ValidateAsync(_userManager, user, model.NewPassword);
                if (result1.Succeeded)
                {
                    user.PasswordHash = passwordHasher?.HashPassword(user, model.NewPassword);
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string id)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            //if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                var passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as
                        IPasswordValidator<User>;
                var passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as
                        IPasswordHasher<User>;

                var result =
                    await passwordValidator?.ValidateAsync(_userManager, user, model.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = passwordHasher?.HashPassword(user, model.NewPassword);
                    await _userManager.UpdateAsync(user);

                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Пользователь не найден");
            }

            return View(model);
        }

        [HttpGet]
        [Area("Admin")]
        [Authorize]
        public async Task<IActionResult> NewCustomerByUserOrders(string id)
        {
            var username = await _userService.GetUserById(id);
            var model = new OrderViewModel();
           
            model.User = username;
            return View(model);
        }


        [HttpPost]
        [Area("Admin")]
        [Authorize]
        public async Task<IActionResult> NewCustomerByUserOrders(OrderViewModel model)
        {
            var username = await _userService.GetUserById(model.User.Id);
            var customer = new CustomerServiceDto()
            {
                Name = model.Order.Name,
                Price = (decimal)model.Order.Price,
                Individual = true
            };

            //_adminCustomerService.CreateCustomerService(customer);

            model.Order.Data=DateTime.Now;
            model.Order.UserId = model.User.Id;
            model.Order.CustomerService = customer;

            _orderService.Create(model.Order);

            return RedirectToAction("Index");
        }




        [HttpGet]
        [Area("Admin")]
        [Authorize]
        public async Task<IActionResult> AllOrdersByUser(string id, int page = 1, int take = 10)
        {
            var username = await _userService.GetUserById(id);
            var orders = _orderService.GetOrder(username.Email, page, take);

            var model = new AdminOrderViewModel(orders);
            model.User = username;
            return View(model);

        }

        [HttpPost]
        [Area("Admin")]
        [Authorize]
        public IActionResult AdminConfirmedOrders(int orderId)
        {
            var response = new JsonResponse();
            var order = _orderService.GetById(orderId);

            //var orderDto = _mapper.Map<OrderDto>(order);

            if (order == null)
            {
                response.status = (int)JsonResponseStatuses.NotFound;
                response.message = "Объект не найден";
            }
            else
            {

                _orderService.AdminConfirmation(order);
                response.status = (int)JsonResponseStatuses.Ok;
                response.message = "Заказ подвержден";
            }

            return Json(response);
        }


        //[Area("Admin")]
        //[Authorize]
        //public IActionResult Search(string searchBy, string searchTerm)
        //{
        //    var list = _userManager.Users.ToList();

        //    if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchTerm))
        //    {
        //        switch (searchBy)
        //        {
        //            case "Email":
        //                list = list.Where(p => p.Email.StartsWith(searchTerm)).OrderBy(p => p.Email).ToList();
        //                break;
        //            case "PhoneNumber":
        //                list = list.Where(p => p.PhoneNumber.Contains(searchTerm)).OrderBy(p => p.PhoneNumber).ToList();
        //                break;
        //            default:
        //                break;
        //        }

        //        // Возвращаем результат поиска
        //        return View("Index", list);
        //    }
        //    return RedirectToAction("Index");
        //}

        [Area("Admin")]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }


            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTranzaction(EditUserViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.Id).Result;

            user.Email = model.Email;
            user.Phone = model.Phone;


            await _userService.Edit(_mapper.Map<UserDto>(user));
            //await _userService.GetUserById(model.Id);
            
            //var balans = _balansService.GetBalansByUserId(model.Id);

            _operationUserService.ListOperationsUser(model.Id);

            var order = new OrderDto()
            {
                IsDeleted = true,
                Data = DateTime.Now,
                Price = (decimal)model.NewPrice,
                UserId = model.Id
            };

           // user.OrdersDto.Add(order);

            var orderDto = _mapper.Map<OrderDto>(order);

            var oper = new OperationUserDto()
            {
                //IsDeleted = true,
                OrderId =  order.Id,
                Order = orderDto,
                UserId = user.Id,
                Price = (decimal)model.NewPrice,
                DataOperation = DateTime.Now
            };

            _operationUserService.AddBalans(oper);
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public PartialViewResult AdminComentInCustomer(int id)
        {
            var item = _orderService.GetById(id);
            var model = new OrderViewModel();
            model.Order = item;

            return PartialView(model);
        }

    }



}

