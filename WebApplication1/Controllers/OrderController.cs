using Microsoft.AspNetCore.Mvc;
using MotoCross.Models.VIewModel;
using MotoCross.Services.OrderService;
using MotoCross.Services.UserService;

namespace MotoCross.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
