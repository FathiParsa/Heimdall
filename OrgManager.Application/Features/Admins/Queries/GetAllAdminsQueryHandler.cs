using AutoMapper;
using MediatR;
using OrgManager.Application.Features.Admins.Dtos;
using OrgManager.Core.Domain.Repositories;

namespace OrgManager.Application.Features.Admins.Queries;

public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminDto>>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;

    public GetAllAdminsQueryHandler(IAdminRepository adminRepository, IMapper mapper)
    {
        _adminRepository = adminRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        var admins = await _adminRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AdminDto>>(admins);
    }
}
