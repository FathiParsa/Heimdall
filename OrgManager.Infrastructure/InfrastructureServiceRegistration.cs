using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using OrgManager.Infrastructure.Persistence.Repositories;
using OrgManager.Infrastructure.Services;

namespace OrgManager.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrgManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OrgManagerConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<ITimeLogRepository, TimeLogRepository>();
        services.AddScoped<ICalendarEventRepository, CalendarEventRepository>();
        services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<ITodoListRepository, TodoListRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<ITimeLogEntryRepository, TimeLogEntryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddTransient<IFileStorageService, FileStorageService>();

        return services;
    }
}
