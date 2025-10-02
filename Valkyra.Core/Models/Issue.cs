namespace Valkyra.Core.Models
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IssueType Type { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public User? AssignedToUser { get; set; }
    }
}