using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Valkyra.Core.Models;
public class IssueConfiguration : IEntityTypeConfiguration<Issue>{

    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property( i => i.Title)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(i => i.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}