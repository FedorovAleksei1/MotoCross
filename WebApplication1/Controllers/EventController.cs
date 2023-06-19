using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Questionary.Core.Services.EventService;
using Questionary.Core.Services.ImportantService;
using Questionary.Web.Areas.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionary.Web.Controllers
{
	public class EventController : Controller
	{
		private readonly IEventService _eventService;
		private readonly IImportantService _importantService;
		public EventController(IEventService eventService, IImportantService importantService)
		{
			_eventService = eventService;
			_importantService = importantService;
		}
		public IActionResult Index(int month)
		{
			var model = new EventListViewModel();
			model.Month = month;		

			return View(model);
		}

		public PartialViewResult EventListWithMonth(int month, int page = 1, int take = 5)
        {
			var model = new EventViewModel();
            var evetnPagination = _eventService.EventsWithMonth(month, page, take);
			model.Item = evetnPagination;
            model.MonthName = GetMonthName(month);
            return PartialView(model);
		}

		public Dictionary<int, IEnumerable<DateTime>> GetDateDictionary()
		{
			Dictionary<int, IEnumerable<DateTime>> importantDataList = new Dictionary<int, IEnumerable<DateTime>>();
			var importans = _importantService.ListImportantsDto().Select(i => i.Id).ToList();
			importans.ForEach(x =>
			{
				importantDataList.Add(x, _eventService.GetDateByImportantId(x));
			});
			return importantDataList;
		}

		private static string GetMonthName(int month)
		{
			string monthName = "";
			switch (month)
			{
				case 1:
					monthName = "января";
					break;
				case 2:
					monthName = "февраля";
					break;
				case 3:
					monthName = "марта";
					break;
				case 4:
					monthName = "апреля";
					break;
				case 5:
					monthName = "мая";
					break;
				case 6:
					monthName = "июня";
					break;
				case 7:
					monthName = "июля";
					break;
				case 8:
					monthName = "августа";
					break;
				case 9:
					monthName = "сентября";
					break;
				case 10:
					monthName = "октября";
					break;
				case 11:
					monthName = "ноября";
					break;
				case 12:
					monthName = "декабря";
					break;

			}
			return monthName;
		}
	}
}
