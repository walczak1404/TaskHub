using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;
using TaskHub.Core.Exceptions;
using TaskHub.Core.ServiceContracts;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Core.Services
{
    public class AssignmentUpdaterService : IAssignmentUpdaterService
    {
        private readonly AppDbContext _db;

        public AssignmentUpdaterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AssignmentResponse> ChangeContent(AssignmentUpdateRequest? assignmentUpdateRequest)
        {
            Validation.Validate(assignmentUpdateRequest);

            Assignment? assignmentFromID = _db.Assignments.FirstOrDefault(a => a.AssignmentID == assignmentUpdateRequest!.AssignmentID);

            if (assignmentFromID == null) throw new NotFoundInDatabaseException("Cannot find task with given ID");

            if (assignmentUpdateRequest!.Content == assignmentFromID.Content) return assignmentFromID.ToAssignmentResponse();

            assignmentFromID.Content = assignmentUpdateRequest!.Content;

            if (await _db.SaveChangesAsync() > 0) return assignmentFromID.ToAssignmentResponse();

            throw new FailedDatabaseOperationException("Cannot modify task content");
        }

        public async Task<AssignmentResponse> ChangeStatus(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignmentFromID = _db.Assignments.FirstOrDefault(a => a.AssignmentID == assignmentID);

            if (assignmentFromID == null) throw new NotFoundInDatabaseException("Cannot find task with given ID");

            assignmentFromID.IsDone = !assignmentFromID.IsDone;

            if (await _db.SaveChangesAsync() > 0) return assignmentFromID.ToAssignmentResponse();

            throw new FailedDatabaseOperationException("Cannot modify task status");
        }
    }
}
