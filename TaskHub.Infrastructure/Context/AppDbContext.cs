using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskHub.Core.Domain.Entities;
using TaskHub.Core.Domain.Entities.Identity;

namespace TaskHub.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IDataProtectionKeyContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            for(int i = 1; i<=5; i++)
            {
                builder.Entity<Assignment>().HasData(new Assignment()
                {
                    AssignmentID = Guid.Parse($"816A{i}6C7-EF5E-49E{i}-BEF7-DB781EA3F{i}92"),
                    Content = $"Task Number {i}",
                    Date = new DateTime(2024, 2, i),
                    AuthorID = Guid.Parse("b34fd626-5019-4cee-06cb-08dc36578af7")
                });
            }
        }
    }
}
