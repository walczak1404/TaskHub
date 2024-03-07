using System.ComponentModel.DataAnnotations;
using TaskHub.Core.CustomValidation;
using TaskHub.Core.Domain.Entities;

namespace TaskHub.Core.DTO
{
    public class AssignmentAddRequest
    {
        [Required(ErrorMessage = "Task content cannot be blank")]
        [StringLength(100)]
        public string? Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Author ID cannot be blank")]
        public Guid? AuthorID { get; set; }

        public Assignment ToAssignment()
        {
            return new Assignment()
            {
                Content = Content,
                Date = Date,
                AuthorID = AuthorID
            };
        }
    }
}
