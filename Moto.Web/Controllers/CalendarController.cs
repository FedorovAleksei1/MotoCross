using Microsoft.AspNetCore.Mvc;
using Moto.Core.Services.CalendarService;

namespace Moto.Web.Controllers
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
