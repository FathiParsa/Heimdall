using MediatR;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IUserRepository userRepository, IAuthenticationService authenticationService, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null)
        {
            // In a real application, you would throw a custom exception
            // and handle it in a middleware to return a 401 Unauthorized.
            throw new System.Exception("Invalid credentials");
        }

        var isAuthenticated = await _authenticationService.AuthenticateAsync(user, request.Password);
        if (!isAuthenticated)
        {
            throw new System.Exception("Invalid credentials");
        }

        return _jwtTokenGenerator.GenerateToken(user);
    }
}
