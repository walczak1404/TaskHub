using System.ComponentModel.DataAnnotations;
using TaskHub.Core.CustomValidation;

namespace TaskHub.Core.DTO
{
    [Serializable]
    public class AssignmentUpdateRequest
    {
        [Required(ErrorMessage = "Task ID cannot be blank")]
        public Guid? AssignmentID { get; set; }

        [Required(ErrorMessage = "Task content cannot be blank")]
        [StringLength(100)]
        public string? Content { get; set; }
    }
}
