using MediatR;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Username, request.Email, "", request.FullName, request.Department, request.Role);
        var passwordHash = _passwordHasher.HashPassword(user, request.Password);

        var userWithPassword = User.Create(request.Username, request.Email, passwordHash, request.FullName, request.Department, request.Role);


        await _userRepository.AddAsync(userWithPassword);

        return userWithPassword.Id;
    }
}
