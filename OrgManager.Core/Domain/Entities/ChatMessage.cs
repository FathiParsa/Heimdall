using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Enums;
using System;

namespace OrgManager.Core.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public Guid ChatRoomId { get; private set; }
    public Guid UserId { get; private set; }
    public string Message { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string? AttachmentUrl { get; private set; }
    public FileType FileType { get; private set; }

    private ChatMessage(Guid id, Guid chatRoomId, Guid userId, string message, string? attachmentUrl, FileType fileType) : base(id)
    {
        ChatRoomId = chatRoomId;
        UserId = userId;
        Message = message;
        Timestamp = DateTime.UtcNow;
        AttachmentUrl = attachmentUrl;
        FileType = fileType;
    }

    public static ChatMessage CreateText(Guid chatRoomId, Guid userId, string message)
    {
        return new ChatMessage(Guid.NewGuid(), chatRoomId, userId, message, null, FileType.Text);
    }

    public static ChatMessage CreateAttachment(Guid chatRoomId, Guid userId, string message, string attachmentUrl, FileType fileType)
    {
        return new ChatMessage(Guid.NewGuid(), chatRoomId, userId, message, attachmentUrl, fileType);
    }
}
