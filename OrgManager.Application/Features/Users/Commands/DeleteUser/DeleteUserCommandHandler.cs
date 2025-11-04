using MediatR;
using Microsoft.Extensions.Logging;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<DeleteUserCommandHandler> _logger;

    public DeleteUserCommandHandler(
        IUserRepository userRepository,
        ILogger<DeleteUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            _logger.LogError("User with id {UserId} not found.", request.Id);
            throw new Exception($"User with id '{request.Id}' not found.");
        }

        user.Delete();

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
