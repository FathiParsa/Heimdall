using Microsoft.AspNetCore.Identity;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Core.Domain.Entities;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthenticationService(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public Task<bool> AuthenticateAsync(User user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return Task.FromResult(result == PasswordVerificationResult.Success);
    }
}
