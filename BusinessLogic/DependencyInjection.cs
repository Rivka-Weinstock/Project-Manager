using AutoMapper;
using BusinessLogic.Profiles;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IStatusService, StatusService>();

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
