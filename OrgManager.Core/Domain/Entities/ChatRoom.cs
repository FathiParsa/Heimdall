using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OrgManager.Core.Domain.Entities;

public class ChatRoom : BaseEntity
{
    public string Name { get; private set; }
    public ICollection<User> Users { get; private set; } = new List<User>();
    public ICollection<ChatMessage> Messages { get; private set; } = new List<ChatMessage>();

    private ChatRoom(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static ChatRoom Create(string name)
    {
        return new ChatRoom(Guid.NewGuid(), name);
    }
}
