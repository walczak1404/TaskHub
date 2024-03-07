using Microsoft.EntityFrameworkCore;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;
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
    }
}
