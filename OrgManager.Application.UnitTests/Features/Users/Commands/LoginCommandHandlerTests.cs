using Moq;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Application.Features.Users.Commands.Login;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrgManager.Application.UnitTests.Features.Users.Commands;

public class LoginCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IAuthenticationService> _authenticationServiceMock;
    private readonly Mock<IJwtTokenGenerator> _jwtTokenGeneratorMock;
    private readonly LoginCommandHandler _handler;

    public LoginCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _authenticationServiceMock = new Mock<IAuthenticationService>();
        _jwtTokenGeneratorMock = new Mock<IJwtTokenGenerator>();
        _handler = new LoginCommandHandler(_userRepositoryMock.Object, _authenticationServiceMock.Object, _jwtTokenGeneratorMock.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var command = new LoginCommand { Username = "testuser", Password = "password" };
        var user = User.Create("testuser", "test@example.com", "hashedpassword", "Test User", "IT", Core.Domain.Enums.Role.RegularUser);
        _userRepositoryMock.Setup(x => x.GetByUsernameAsync(command.Username)).ReturnsAsync(user);
        _authenticationServiceMock.Setup(x => x.AuthenticateAsync(user, command.Password)).ReturnsAsync(true);
        _jwtTokenGeneratorMock.Setup(x => x.GenerateToken(user)).Returns("token");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("token", result);
    }
}
