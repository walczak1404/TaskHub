using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;
using TaskHub.Core.ServiceContracts;

namespace TaskHub.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentGetterService _assignmentGetterService;
        private readonly IAssignmentAdderService _assignmentAdderService;
        private readonly IAssignmentUpdaterService _assignmentUpdaterService;
        private readonly IAssignmentDeleterService _assignmentDeleterService;

        public AssignmentsController(IAssignmentGetterService assignmentGetterService, IAssignmentAdderService assignmentAdderService, IAssignmentUpdaterService assignmentUpdaterService, IAssignmentDeleterService assignmentDeleterService)
        {
            _assignmentGetterService = assignmentGetterService;
            _assignmentAdderService = assignmentAdderService;
            _assignmentUpdaterService = assignmentUpdaterService;
            _assignmentDeleterService = assignmentDeleterService;
        }

        [Route("/{selectedDate:datetime?}")]
        public async Task<IActionResult> List(DateTime? selectedDate)
        {
            DateTime date = selectedDate != null ? selectedDate.Value : DateTime.Today.Date;

            ViewBag.SelectedDate = date.ToString("dd.MM.yyyy");
            ViewBag.SelectedDateLink = date.ToString("yyyy-MM-dd");

            Guid userID = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserID = userID;

            List<AssignmentResponse> assignments = await _assignmentGetterService.GetAssignmentsForDay(date, userID);

            AssignmentUpdateRequest? updateModel = null;

            if ((Guid?)TempData["UpdateID"] != null)
            {
                AssignmentResponse updateModelResponse = await _assignmentGetterService.GetAssignmentByID((Guid?)TempData["UpdateID"]);
                updateModel = updateModelResponse.ToUpdateRequest();
            }

            ListViewModel viewModel = new ListViewModel()
            {
                Assignments = assignments,
                UpdateRequest = updateModel == null ? null : updateModel
            };

            return View(viewModel);
        }


        [Route("/edit/{assignmentID:guid?}")]
        public async Task<IActionResult> RenderEditPartial(Guid assignmentID, DateTime selectedDate)
        {
            AssignmentResponse assignment = await _assignmentGetterService.GetAssignmentByID(assignmentID);

            ViewBag.SelectedDateLink = selectedDate.ToString("yyyy-MM-dd");

            return PartialView("_EditModalPartial", assignment.ToUpdateRequest());
        }

        [HttpPost]
        [Route("/update")]
        public async Task<IActionResult> EditAssignment(AssignmentUpdateRequest assignmentUpdateRequest, DateTime? selectedDate)
        {
            if (!ModelState.IsValid)
            {
                TempData["UpdateID"] = assignmentUpdateRequest.AssignmentID;
                return RedirectToAction("List", new {selectedDate = selectedDate?.ToString("yyyy-MM-dd")});
            }

            await _assignmentUpdaterService.ChangeContent(assignmentUpdateRequest);

            return RedirectToAction("List", new { selectedDate = selectedDate?.ToString("yyyy-MM-dd") });
        }

        [Route("/delete/{assignmentID:guid}")]
        public async Task<IActionResult> DeleteAssignment(Guid assignmentID, DateTime? selectedDate)
        {
            await _assignmentDeleterService.RemoveAssignment(assignmentID);

            return RedirectToAction("List", new { selectedDate =  selectedDate?.ToString("yyyy-MM-dd")});
        }

        [Route("/update-status/{assignmentID:guid}")]
        public async Task<IActionResult> ChangeAssignmentStatus(Guid assignmentID, DateTime? selectedDate)
        {
            await _assignmentUpdaterService.ChangeStatus(assignmentID);

            return RedirectToAction("List", new { selectedDate = selectedDate?.ToString("yyyy-MM-dd") });
        }

        [HttpPost]
        [Route("/add-task")]
        public async Task<IActionResult> AddTask(AssignmentAddRequest assignmentAddRequest, DateTime? selectedDate)
        {
            Guid userID = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            assignmentAddRequest.AuthorID = userID;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", new { selectedDate = selectedDate?.ToString("yyyy-MM-dd") });
            }

            await _assignmentAdderService.AddAssignment(assignmentAddRequest);

            return RedirectToAction("List", new { selectedDate = selectedDate?.ToString("yyyy-MM-dd") });
        }
    }
}
