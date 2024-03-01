using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHub.Core.CustomValidation;

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
}
