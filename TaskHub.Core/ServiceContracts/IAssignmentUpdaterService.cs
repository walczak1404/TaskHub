using TaskHub.Core.DTO;

namespace TaskHub.Core.ServiceContracts
{
    /// <summary>
    /// Interface for updating assignments
    /// </summary>
    public interface IAssignmentUpdaterService
    {
        /// <summary>
        /// Changes content of the assignment
        /// </summary>
        /// <param name="updateRequest">DTO containing new content of the assignment</param>
        /// <returns>Updated assignment</returns>
        Task<AssignmentResponse> ChangeContent(AssignmentUpdateRequest? assignmentUpdateRequest);

        /// <summary>
        /// Changes status(IsDone property) of the assignment
        /// </summary>
        /// <param name="assignmentID">ID of changed assignment</param>
        /// <returns>Modified assignment</returns>
        Task<AssignmentResponse> ChangeStatus(Guid? assignmentID);
    }
}
