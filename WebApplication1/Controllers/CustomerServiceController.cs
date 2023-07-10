using Domain.Dto;
using Domain.Models;
using Domain.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Json;
using MotoCross.Services.CustomerServiceService;
using Questionary.Core.Services.AdminService.AdminCastomerService;
using Questionary.Web.Areas.Admin.ViewModels.AdminViewModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questionary.Web.Controllers
{
    public class CustomerServiceController : Controller
    {
        private readonly IAdminCustomerService _adminCustomerService;
        private readonly ICustomerServiceService _customerServiceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerServiceController(IAdminCustomerService adminCustomerService, ICustomerServiceService customerServiceService, IHttpContextAccessor httpContextAccessor)
        {
            _adminCustomerService = adminCustomerService;
            _customerServiceService = customerServiceService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {

            var model = new AdminCustomerServiceViewModel();
            var customer = _adminCustomerService.AllCustomerService();
            model.Customers = customer;
            return View(model);
        }



        [HttpPost]
        public IActionResult Addorder(int customerId)
        {
            HttpContext context = _httpContextAccessor.HttpContext;

            string username = "";
            // Проверка, авторизован ли пользователь
            if ( context.User.Identity.IsAuthenticated)
            {
                // Получение имени пользователя
                username = context.User.Identity.Name;

                // Дополнительные действия с авторизованным пользователем
                // ...
            }
            var response = new JsonResponse();

            if(!string.IsNullOrEmpty(username))
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
