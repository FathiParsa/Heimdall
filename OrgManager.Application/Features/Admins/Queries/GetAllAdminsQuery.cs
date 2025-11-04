using MediatR;
using OrgManager.Application.Features.Admins.Dtos;

namespace OrgManager.Application.Features.Admins.Queries;

public class GetAllAdminsQuery : IRequest<IEnumerable<AdminDto>>
{
}
