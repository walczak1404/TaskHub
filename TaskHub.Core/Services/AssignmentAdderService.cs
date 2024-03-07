using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;
using TaskHub.Core.Exceptions;
using TaskHub.Core.ServiceContracts;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Core.Services
{
    public class AssignmentAdderService : IAssignmentAdderService
    {
        private readonly AppDbContext _db;

        public AssignmentAdderService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AssignmentResponse> AddAssignment(AssignmentAddRequest? assignmentAddRequest)
        {
            Validation.Validate(assignmentAddRequest);

            Assignment assignment = assignmentAddRequest!.ToAssignment();

            _db.Assignments.Add(assignment);

            if (await _db.SaveChangesAsync() > 0) return assignment.ToAssignmentResponse();
            else throw new FailedDatabaseOperationException("Cannot add task to database");
        }
    }
}
