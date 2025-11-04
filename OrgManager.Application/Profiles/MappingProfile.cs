using AutoMapper;
using OrgManager.Application.Features.Admins.Dtos;
using OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;
using OrgManager.Application.Features.Todo.Dtos;
using OrgManager.Application.Features.Users.Queries.GetAllUsers;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<TimeLogEntry, TimeLogReportDto>();
        CreateMap<User, AdminDto>();
        CreateMap<TodoList, TodoListDto>();
        CreateMap<TodoItem, TodoItemDto>();
    }
}
