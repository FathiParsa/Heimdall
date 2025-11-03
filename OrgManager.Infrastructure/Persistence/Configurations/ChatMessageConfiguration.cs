using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Infrastructure.Persistence.Configurations;

public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.ChatRoomId)
            .IsRequired();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.Message)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(c => c.Timestamp)
            .IsRequired();

        builder.Property(c => c.AttachmentUrl)
            .HasMaxLength(2000);

        builder.Property(c => c.FileType)
            .IsRequired();
    }
}
