using MediatR;
using OrgManager.Core.Domain.Repositories;

namespace OrgManager.Application.Features.Dashboard.Queries;

public class GetUserCountQueryHandler : IRequestHandler<GetUserCountQuery, int>
{
    private readonly IUserRepository _userRepository;

    public GetUserCountQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetCountAsync();
    }
}
