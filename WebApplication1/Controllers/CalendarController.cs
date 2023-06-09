using Microsoft.AspNetCore.Mvc;
using MotoCross.Services.OrderService;
using Questionary.Core.Services.CalendarService;

namespace Questionary.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService) 
        {
            _calendarService = calendarService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
    }
}
