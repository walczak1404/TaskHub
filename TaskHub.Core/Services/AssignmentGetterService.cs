using Microsoft.EntityFrameworkCore;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;
using TaskHub.Core.Exceptions;
using TaskHub.Core.ServiceContracts;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Core.Services
{
    public class AssignmentGetterService : IAssignmentGetterService
    {
        private readonly AppDbContext _db;

        public AssignmentGetterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<AssignmentResponse>> GetAssignmentsForDay(DateTime? day, Guid? authorID)
        {
            if (day == null) throw new ArgumentNullException(nameof(day));
            if (authorID == null) throw new ArgumentNullException(nameof(authorID));

            List<Assignment> fetchedAssignments = await _db.Assignments.Where(a => a.Date == day && a.AuthorID == authorID).ToListAsync();

            return fetchedAssignments.Select(a => a.ToAssignmentResponse()).ToList();
        }

        public async Task<AssignmentResponse> GetAssignmentByID(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignment = await _db.Assignments.FirstOrDefaultAsync(a => a.AssignmentID == assignmentID);

            if (assignment == null) throw new NotFoundInDatabaseException("Cannot find assignment with given ID");

            return assignment.ToAssignmentResponse();
        }
    }
}
