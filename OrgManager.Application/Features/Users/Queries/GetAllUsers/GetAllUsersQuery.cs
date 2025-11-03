using MediatR;
using System.Collections.Generic;

namespace OrgManager.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}
