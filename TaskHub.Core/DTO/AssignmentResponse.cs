using TaskHub.Core.Domain.Entities;

namespace TaskHub.Core.DTO
{
    public class AssignmentResponse
    {
        public Guid AssignmentID { get; set; }

        public string? Content { get; set; }

        public DateTime? Date { get; set; }

        public bool IsDone { get; set; }

        public Guid? AuthorID { get; set; }
    }

    public static class AssignmentExtensions
    {
        public static AssignmentResponse ToAssignmentResponse(this Assignment assignment)
        {
            return new AssignmentResponse()
            {
                AssignmentID = assignment.AssignmentID,
                Content = assignment.Content,
                Date = assignment.Date,
                IsDone = assignment.IsDone,
                AuthorID = assignment.AuthorID
            };
        }
    }
}
