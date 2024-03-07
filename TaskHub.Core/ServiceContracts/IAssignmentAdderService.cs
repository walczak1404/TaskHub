using TaskHub.Core.DTO;

namespace TaskHub.Core.ServiceContracts
{
    /// <summary>
    /// Interface for adding Assignments to database
    /// </summary>
    public interface IAssignmentAdderService
    {
        /// <summary>
        /// Adds assignment to database
        /// </summary>
        /// <param name="assignmentAddRequest">Assignment to add</param>
        /// <returns>Added assignment</returns>
        Task<AssignmentResponse> AddAssignment(AssignmentAddRequest? assignmentAddRequest);
    }
}
