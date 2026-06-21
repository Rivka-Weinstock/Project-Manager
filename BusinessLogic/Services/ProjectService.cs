using AutoMapper;
using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Models.DTOs;
using Models.Entities;

namespace BusinessLogic.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return project is null ? null : _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> AddAsync(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var created = await _projectRepository.AddAsync(project);
        return _mapper.Map<ProjectDto>(created);
    }

    public async Task UpdateAsync(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        await _projectRepository.UpdateAsync(project);
    }

    public async Task DeleteAsync(int id)
    {
        await _projectRepository.DeleteAsync(id);
    }
}
