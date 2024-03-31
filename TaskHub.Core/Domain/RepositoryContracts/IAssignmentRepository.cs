using TaskHub.Core.Domain.Entities;
using TaskHub.Core.DTO;

namespace TaskHub.Core.Domain.RepositoryContracts
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAssignmentsForDay(DateTime day, Guid authorID);

        Task<Assignment?> GetAssignmentByID(Guid assignmentID);

        Task<Assignment> AddAssignment(Assignment assignment);

        Task RemoveAssignment(Assignment assignment);

        Task<Assignment> ChangeContent(Assignment modifiedAssignment, string newContent);

        Task<Assignment> ChangeStatus(Assignment modifiedAssignment);
    }
}
