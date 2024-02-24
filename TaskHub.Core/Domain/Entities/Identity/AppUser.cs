using Microsoft.AspNetCore.Identity;

namespace TaskHub.Core.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public virtual ICollection<Assignment>? Assignments { get; set; }
    }
}
