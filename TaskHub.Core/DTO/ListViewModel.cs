using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.Core.DTO
{
    public class ListViewModel
    {
        public List<AssignmentResponse> Assignments { get; set; }
        public AssignmentUpdateRequest? UpdateRequest { get; set; }
    }
}
