using MediatR;
using Microsoft.Extensions.Logging;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UpdateUserCommandHandler> _logger;

    public UpdateUserCommandHandler(
        IUserRepository userRepository,
        ILogger<UpdateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            _logger.LogError("User with id {UserId} not found.", request.Id);
            throw new Exception($"User with id '{request.Id}' not found.");
        }

        user.Update(request.Username, request.Email, request.FullName, request.Department, request.Role);

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
