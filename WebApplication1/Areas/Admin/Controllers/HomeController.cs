﻿using Domain.Models;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;
using System.Threading.Tasks;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public HomeController(SignInManager<User> signInManager, IOrderService orderService, IUserService userService)
        {
            _signInManager = signInManager;
            _orderService = orderService;
            _userService = userService;
        }

        [Area("Admin")]
        [Authorize]
        // GET: HomeController
        public ActionResult Index(int page, int take)
        {
            var model = new AdminOrderViewModel();            

            var orders = _orderService.GetAllOrder(page, take);
            foreach(var order in orders.Elements)
            {
                var username = _userService.GetUserById(order.UserId).Result;
                model.Dictionaryobject.Add(order, username);
            }

            model.Orders = orders;
            return View(model);
        }


        

        //// GET: HomeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: HomeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HomeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
