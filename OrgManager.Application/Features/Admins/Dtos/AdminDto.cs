namespace OrgManager.Application.Features.Admins.Dtos;

public class AdminDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? Department { get; set; }
}
