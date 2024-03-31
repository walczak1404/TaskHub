using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskHub.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature != null && exceptionHandlerPathFeature.Error != null) ViewBag.ErrorMessage = exceptionHandlerPathFeature.Error.Message;

            return View();
        }
    }
}
