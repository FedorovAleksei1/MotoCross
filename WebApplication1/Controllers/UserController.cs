using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Models;
using MotoCross.Models.VIewModel;
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

        public UserController(UserManager<User> userManager
            , IUserService userService
            , SignInManager<User> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}