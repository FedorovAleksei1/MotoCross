using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Questionary.Web.Areas.Admin.ViewModel.AdminViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionary.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            return View(_roleManager.Roles.ToList());
        }

        public IActionResult Create()
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            if (string.IsNullOrEmpty(name)) return View(name);

            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> Edit(string userId)
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            // получем список ролей пользователя
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            if (!User.IsInRole("admin"))
                RedirectToAction("Index", "Home", new { area = "Admin" });

            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            // получем список ролей пользователя
            var userRoles = await _userManager.GetRolesAsync(user);
            // получаем список ролей, которые были добавлены
            var addedRoles = roles.Except(userRoles);
            // получаем роли, которые были удалены
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);

            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return RedirectToAction("UserList");

        }
    }
}
