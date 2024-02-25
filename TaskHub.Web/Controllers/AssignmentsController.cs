using Microsoft.AspNetCore.Mvc;

namespace TaskHub.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        [Route("/")]
        public IActionResult List()
        {
            return View();
        }
    }
}
