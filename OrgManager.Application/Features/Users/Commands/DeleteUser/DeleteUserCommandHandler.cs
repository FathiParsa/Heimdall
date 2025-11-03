using MediatR;
using OrgManager.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            // In a real application, you would throw a custom exception.
            throw new System.Exception("User not found");
        }

        await _userRepository.DeleteAsync(user);
    }
}
