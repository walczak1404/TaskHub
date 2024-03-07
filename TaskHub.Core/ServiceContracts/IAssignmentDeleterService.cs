using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.Core.ServiceContracts
{
    /// <summary>
    /// Interface for removing assignments from database
    /// </summary>
    public interface IAssignmentDeleterService
    {
        /// <summary>
        /// Removes assignment from database
        /// </summary>
        /// <param name="assignmentID">ID of deleted assignment</param>
        /// <returns>True if assignment was deleted</returns>
        Task<bool> RemoveAssignment(Guid? assignmentID);
    }
}
