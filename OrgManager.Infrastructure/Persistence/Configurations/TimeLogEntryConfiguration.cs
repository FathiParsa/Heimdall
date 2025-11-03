using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Infrastructure.Persistence.Configurations;

public class TimeLogEntryConfiguration : IEntityTypeConfiguration<TimeLogEntry>
{
    public void Configure(EntityTypeBuilder<TimeLogEntry> builder)
    {
        builder.ToTable("TimeLogEntries");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.DurationInMinutes)
            .IsRequired();

        builder.Property(t => t.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(500);
    }
}
