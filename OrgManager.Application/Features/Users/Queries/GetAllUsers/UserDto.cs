using OrgManager.Core.Domain.Enums;
using System;

namespace OrgManager.Application.Features.Users.Queries.GetAllUsers;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Department { get; set; }
    public Role Role { get; set; }
}
