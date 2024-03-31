using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.RepositoryContracts;
using TaskHub.Core.DTO;
using TaskHub.Core.ServiceContracts;

namespace TaskHub.Core.Services
{
    public class AssignmentAdderService : IAssignmentAdderService
    {
        private readonly IAssignmentRepository _assignments;

        public AssignmentAdderService(IAssignmentRepository assignmentRepository)
        {
            _assignments = assignmentRepository;
        }

        public async Task<AssignmentResponse> AddAssignment(AssignmentAddRequest? assignmentAddRequest)
        {
            Validation.Validate(assignmentAddRequest);

            Assignment assignment = assignmentAddRequest!.ToAssignment();

            Assignment addedAssignment = await _assignments.AddAssignment(assignment);

            return addedAssignment.ToAssignmentResponse();
        }
    }
}
