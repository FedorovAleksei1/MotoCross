using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Models;
using MotoCross.Models.VIewModel;
using MotoCross.Services.UserService;
using System;
using System.Threading.Tasks;

namespace MotoCross.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUserById(id);
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
    }
}