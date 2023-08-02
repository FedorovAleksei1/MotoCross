using Microsoft.AspNetCore.Mvc;

namespace Questionary.Web.Controllers
{
    public class ErrorController : Controller
    {
        //[Route("Error/NotFound")]
        //public IActionResult NotFoundPage()
        //{
        //    Response.StatusCode = 404;
        //    return View("NotFound");
        //}

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }

}
