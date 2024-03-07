using TaskHub.Core.DTO;

namespace TaskHub.Core.ServiceContracts
{
    /// <summary>
    /// Interface for getting assignments from database
    /// </summary>
    public interface IAssignmentGetterService
    {
        /// <summary>
        /// Fetches assignmets for specified day.
        /// </summary>
        /// <param name="day">Day of fetched assignments</param>
        /// <param name="authorID">ID of the author of assignments</param>
        /// <returns>List of Assignments</returns>
        Task<List<AssignmentResponse>> GetAssignmentsForDay(DateTime? day, Guid? authorID);
    }
}
