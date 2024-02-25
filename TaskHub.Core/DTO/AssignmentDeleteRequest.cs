using System.ComponentModel.DataAnnotations;

namespace TaskHub.Core.DTO
{
    public class AssignmentDeleteRequest
    {
        [Required(ErrorMessage = "Task ID cannot be blank")]
        public Guid AssignmentID { get; set; }

        [Required(ErrorMessage = "Author ID cannot be blank")]
        public Guid? AuthorID { get; set; }
    }
}
