using Microsoft.EntityFrameworkCore;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.RepositoryContracts;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _db;

        public AssignmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Assignment>> GetAssignmentsForDay(DateTime day, Guid authorID)
        {
            List<Assignment> fetchedAssignments = await _db.Assignments.Where(a => a.Date == day && a.AuthorID == authorID).ToListAsync();
            return fetchedAssignments;
        }

        public async Task<Assignment?> GetAssignmentByID(Guid assignmentID)
        {
            Assignment? assignment =  await _db.Assignments.FirstOrDefaultAsync(a => a.AssignmentID == assignmentID);
            return assignment;
        }

        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            _db.Assignments.Add(assignment);

            if (await _db.SaveChangesAsync() > 0) return assignment;
            else throw new DbUpdateException("Cannot add assignment to database");
        }

        public async Task RemoveAssignment(Assignment assignment)
        {
            _db.Assignments.Remove(assignment);

            if (await _db.SaveChangesAsync() == 0) throw new DbUpdateException("Cannot remove task from database");
        }

        public async Task<Assignment> ChangeContent(Assignment modifiedAssignment, string newContent)
        {
            modifiedAssignment.Content = newContent;

            if (await _db.SaveChangesAsync() > 0) return modifiedAssignment;
            else throw new DbUpdateException("Cannot modify task content");
        }

        public async Task<Assignment> ChangeStatus(Assignment modifiedAssignment)
        {
            modifiedAssignment.IsDone = !modifiedAssignment.IsDone;

            if (await _db.SaveChangesAsync() > 0) return modifiedAssignment;
            else throw new DbUpdateException("Cannot modify task status");
        }
    }
}
