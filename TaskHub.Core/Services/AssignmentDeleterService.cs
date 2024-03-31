using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.RepositoryContracts;
using TaskHub.Core.ServiceContracts;

namespace TaskHub.Core.Services
{
    public class AssignmentDeleterService : IAssignmentDeleterService
    {
        private readonly IAssignmentRepository _assignments;

        public AssignmentDeleterService(IAssignmentRepository assignments)
        {
            _assignments = assignments;
        }

        public async Task RemoveAssignment(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignmentFromID = await _assignments.GetAssignmentByID(assignmentID.Value);

            if (assignmentFromID == null) throw new ArgumentException("Cannot find task with given ID");

            await _assignments.RemoveAssignment(assignmentFromID);

        }
    }
}
