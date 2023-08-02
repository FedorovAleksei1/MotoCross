using Microsoft.AspNetCore.Mvc;

namespace Questionary.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        //public IActionResult NotFoundPage()
        //{
        //    Response.StatusCode = 404;
        //    return View("NotFound");
        //}

        [Route("Error/NotFound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }

}
