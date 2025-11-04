using MediatR;
using OrgManager.Application.Features.Users.DTOs;

namespace OrgManager.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}
