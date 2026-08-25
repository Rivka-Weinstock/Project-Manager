using BusinessLogic.Mapping;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;

namespace BusinessLogic.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        return projects.Select(project => project.ToDto());
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return project?.ToDto();
    }

    public async Task<ProjectDto> AddAsync(ProjectDto projectDto)
    {
        var project = projectDto.ToEntity();
        var created = await _projectRepository.AddAsync(project);
        return created.ToDto();
    }

    public async Task UpdateAsync(ProjectDto projectDto)
    {
        var project = projectDto.ToEntity();
        await _projectRepository.UpdateAsync(project);
    }

    public async Task DeleteAsync(int id)
    {
        await _projectRepository.DeleteAsync(id);
    }
}
