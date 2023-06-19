using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.UserService;
using System.Threading.Tasks;
using System;
using System.Linq;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;

namespace Questionary.Web.Areas.Admin.Controllers
{ 
    public class AdminUserController : Controller
    {
        
        private readonly UserManager<User> _userManager;
        private IUserService _userService;


        public AdminUserController(UserManager<User> userManager,  IUserService userService )
        {
            _userManager = userManager;
            
            _userService = userService;
           
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult Index(string searchString)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Index", "Home", new { area = "" });

            var data = _userManager.Users.AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
                data = data.Where(_ => _.Email != null && _.Email.ToLower().Contains(searchString.ToLower())).AsEnumerable();

            return View(data);
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

            if (user == null)
                return NotFound();


            var model = new EditUserViewModel { Id = user.Id, Email = user.Email, PhoneNumber = user.PhoneNumber };

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
            if (user == null) return View(model);

            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
           
            if (result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

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
        [Area("Admin")]
        [Authorize]
        public IActionResult Search(string searchBy, string searchTerm)
        {
            var list = _userManager.Users.ToList();

            if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchTerm))
            {
                switch (searchBy)
                {
                    case "Email":
                        list = list.Where(p => p.Email.StartsWith(searchTerm)).OrderBy(p => p.Email).ToList();
                        break;
                    case "PhoneNumber":
                        list = list.Where(p => p.PhoneNumber.Contains(searchTerm)).OrderBy(p => p.PhoneNumber).ToList();
                        break;
                    default:
                        break;
                }

                // Возвращаем результат поиска
                return View("Index", list);
            }
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [Authorize]
        [HttpPost]
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
    }
}
