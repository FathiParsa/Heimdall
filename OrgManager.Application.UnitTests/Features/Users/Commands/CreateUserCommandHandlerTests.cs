using Moq;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Application.Features.Users.Commands.CreateUser;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrgManager.Application.UnitTests.Features.Users.Commands;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IPasswordHasher> _passwordHasherMock;
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _handler = new CreateUserCommandHandler(_userRepositoryMock.Object, _passwordHasherMock.Object);
    }

    [Fact]
    public async Task Handle_Should_CreateUserAndReturnUserId()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password",
            FullName = "Test User",
            Department = "IT",
            Role = Role.RegularUser
        };
        var hashedPassword = "hashedpassword";
        _passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<User>(), command.Password)).Returns(hashedPassword);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(x => x.AddAsync(It.Is<User>(u => u.Username == command.Username && u.Email == command.Email)), Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }
}
