using AutoMapper;
using OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;
using OrgManager.Application.Features.Users.Queries.GetAllUsers;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<TimeLogEntry, TimeLogReportDto>();
    }
}
