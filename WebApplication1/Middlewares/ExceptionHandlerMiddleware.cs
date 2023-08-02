using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MotoCross.Controllers;

namespace Questionary.Web.Middlewares
{
    public class ExceptionHandlerMiddleware : Controller
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception)
            {
                httpContext.Response.Redirect("/Error/NotFound");
            }

        }

    }
}