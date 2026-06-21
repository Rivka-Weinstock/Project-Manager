using Models.DTOs;

namespace BusinessLogic.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllAsync();
    Task<ProjectDto?> GetByIdAsync(int id);
    Task<ProjectDto> AddAsync(ProjectDto projectDto);
    Task UpdateAsync(ProjectDto projectDto);
    Task DeleteAsync(int id);
}
