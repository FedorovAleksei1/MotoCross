using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.OrderService;

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
