using System.ComponentModel.DataAnnotations;
using TaskHub.Core.CustomValidation;

namespace TaskHub.Core.DTO
{
    public class AssignmentAddRequest
    {
        [Required(ErrorMessage = "Task content cannot be blank")]
        [StringLength(100)]
        public string? Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateBetweenTodayAndTwoYearsUp(ErrorMessage = "Task date should be between today and two years from now")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Author ID cannot be blank")]
        public Guid? AuthorID { get; set; }
    }
}
