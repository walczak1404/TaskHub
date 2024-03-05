using Microsoft.AspNetCore.Mvc;

namespace TaskHub.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        [Route("/{selectedDate:datetime?}")]
        public IActionResult List(DateTime? selectedDate)
        {
            ViewBag.SelectedDate = selectedDate != null ? selectedDate.Value.ToString("dd.MM.yyyy") : DateTime.Today.Date.ToString("dd.MM.yyyy");

            return View();
        }
    }
}
