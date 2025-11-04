using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Application.Exceptions;
using OrgManager.Application.Features.Users.DTOs;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper,
        ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
        if (existingUser != null)
        {
            _logger.LogWarning("Username {Username} already exists.", request.Username);
            throw new BadRequestException($"Username '{request.Username}' already exists.");
        }

        existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
        {
            _logger.LogWarning("Email {Email} already exists.", request.Email);
            throw new BadRequestException($"Email '{request.Email}' already exists.");
        }

        var passwordHash = _passwordHasher.HashPassword(request.Password);

        var user = User.Create(
            request.Username,
            request.Email,
            passwordHash,
            request.FullName,
            request.Department,
            request.Role);

        await _userRepository.AddAsync(user);

        return _mapper.Map<UserDto>(user);
    }
}
