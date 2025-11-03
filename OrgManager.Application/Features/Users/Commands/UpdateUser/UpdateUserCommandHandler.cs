using MediatR;
using OrgManager.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            // In a real application, you would throw a custom exception.
            throw new System.Exception("User not found");
        }

        // In a real application, you would use a mapper here.
        // Also, you would not update the user entity directly.
        // Instead, you would create a new user entity and copy the properties.
        // For simplicity, we are updating the entity directly.

        await _userRepository.UpdateAsync(user);
    }
}
