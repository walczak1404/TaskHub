using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.RepositoryContracts;
using TaskHub.Core.DTO;
using TaskHub.Core.ServiceContracts;

namespace TaskHub.Core.Services
{
    public class AssignmentUpdaterService : IAssignmentUpdaterService
    {
        private readonly IAssignmentRepository _assignments;

        public AssignmentUpdaterService(IAssignmentRepository assignments)
        {
            _assignments = assignments;
        }

        public async Task<AssignmentResponse> ChangeContent(AssignmentUpdateRequest? assignmentUpdateRequest)
        {
            Validation.Validate(assignmentUpdateRequest);

            Assignment? assignmentFromID = await _assignments.GetAssignmentByID(assignmentUpdateRequest.AssignmentID!.Value);

            if (assignmentFromID == null) throw new ArgumentException("Cannot find task with given ID");

            if (assignmentUpdateRequest!.Content == assignmentFromID.Content) return assignmentFromID.ToAssignmentResponse();

            Assignment modifiedAssignment = await _assignments.ChangeContent(assignmentFromID, assignmentUpdateRequest!.Content!);

            return modifiedAssignment.ToAssignmentResponse();
        }

        public async Task<AssignmentResponse> ChangeStatus(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignmentFromID = await _assignments.GetAssignmentByID(assignmentID.Value);

            if (assignmentFromID == null) throw new ArgumentException("Cannot find task with given ID");

            Assignment modifiedAssignment = await _assignments.ChangeStatus(assignmentFromID);

            return modifiedAssignment.ToAssignmentResponse();
        }
    }
}
