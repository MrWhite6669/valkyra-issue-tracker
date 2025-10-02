using Microsoft.EntityFrameworkCore;
using Valkyra.Core.Models;

namespace Valkyra.Infrastructure.DbContext
{
    public class ValkyraDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ValkyraDbContext(DbContextOptions<ValkyraDbContext> options)
            : base(options)
        {
        }

    public DbSet<Issue> Issues => Set<Issue>();
    public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValkyraDbContext).Assembly);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.AssignedToUser)
                .WithMany()
                .HasForeignKey(i => i.AssignedToUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed data

            var userId = new Guid("11111111-1111-1111-1111-111111111111");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    UserName = "demo.user",
                    Email = "demo.user@example.com",
                    DisplayName = "Demo User",
                    CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity<Issue>().HasData(
                new Issue
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Title = "Sample Issue 1",
                    Description = "This is a sample issue for demonstration purposes.",
                    Priority = IssuePriority.Medium,
                    Status = IssueStatus.Open,
                    CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                    AssignedToUserId = userId,
                    Type = IssueType.Bug
                },
                new Issue
                {
                    Id = new Guid("33333333-3333-3333-3333-333333333333"),
                    Title = "Sample Issue 2",
                    Description = "This is another sample issue for demonstration purposes.",
                    Priority = IssuePriority.High,
                    Status = IssueStatus.InProgress,
                    CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                    AssignedToUserId = userId,
                    Type = IssueType.Feature
                }
            );
        }
    }
}