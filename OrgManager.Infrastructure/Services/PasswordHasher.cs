using Microsoft.AspNetCore.Identity;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordHasher(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(User user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }
}
