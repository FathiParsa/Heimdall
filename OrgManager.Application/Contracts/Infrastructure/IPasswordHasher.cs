namespace OrgManager.Application.Contracts.Infrastructure;

public interface IPasswordHasher
{
    string HashPassword(string password);
}
