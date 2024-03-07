using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Exceptions;
using TaskHub.Core.ServiceContracts;
using TaskHub.Infrastructure.Context;

namespace TaskHub.Core.Services
{
    public class AssignmentDeleterService : IAssignmentDeleterService
    {
        private readonly AppDbContext _db;

        public AssignmentDeleterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> RemoveAssignment(Guid? assignmentID)
        {
            if (assignmentID == null) throw new ArgumentNullException(nameof(assignmentID));

            Assignment? assignmentFromID = _db.Assignments.FirstOrDefault(a => a.AssignmentID == assignmentID);

            if (assignmentFromID == null) throw new NotFoundInDatabaseException("Cannot find task with given ID");

            _db.Assignments.Remove(assignmentFromID);

            if (await _db.SaveChangesAsync() > 0) return true;
            else throw new FailedDatabaseOperationException("Cannot remove task from database");
        }
    }
}
