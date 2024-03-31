using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.RepositoryContracts;
using TaskHub.Core.DTO;
using TaskHub.Core.ServiceContracts;

namespace TaskHub.Core.Services
{
    public class AssignmentGetterService : IAssignmentGetterService
    {
        private readonly IAssignmentRepository _assignments;

        public AssignmentGetterService(IAssignmentRepository assignments)
        {
            _assignments = assignments;
        }

        public async Task<List<AssignmentResponse>> GetAssignmentsForDay(DateTime? day, Guid? authorID)
        {
            if (day == null) throw new ArgumentNullException(nameof(day));
            if (authorID == null) throw new ArgumentNullException(nameof(authorID));

            List<Assignment> fetchedAssignments = await _assignments.GetAssignmentsForDay(day.Value, authorID.Value);

            return fetchedAssignments.Select(a => a.ToAssignmentResponse()).ToList();
        }

        public async Task<AssignmentResponse> GetAssignmentByID(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignment = await _assignments.GetAssignmentByID(assignmentID.Value);

            if (assignment == null) throw new ArgumentException("Cannot find assignment with given ID");

            return assignment.ToAssignmentResponse();
        }
    }
}
