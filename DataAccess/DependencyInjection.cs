using BusinessLogic.Repositories.Interfaces;
using DataAccess.Data;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ProjectManagementContext>(options =>
            options.UseMySql(connectionString, ServerVersion.Parse("8.0.0-mysql")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();

        return services;
    }
}
