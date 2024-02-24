using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskHub.Core.Domain.Entities.Identity;

namespace TaskHub.Core.Domain.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AssignmentID { get; set; }

        [StringLength(100)]
        public string? Content { get; set; }

        public DateTime? Date { get; set; }

        public Guid? AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual AppUser? Author { get; set; }
    }
}
