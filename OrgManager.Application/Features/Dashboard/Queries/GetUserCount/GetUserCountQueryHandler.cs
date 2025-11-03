using MediatR;
using OrgManager.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Dashboard.Queries.GetUserCount;

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
