using Models.Entities;

namespace BusinessLogic.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(int id);
}
