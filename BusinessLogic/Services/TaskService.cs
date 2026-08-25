using AutoMapper;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;
using Models.Entities;

namespace BusinessLogic.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task is null ? null : _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto> AddAsync(TaskDto taskDto)
    {
        var task = _mapper.Map<TaskItem>(taskDto);
        var created = await _taskRepository.AddAsync(task);
        return _mapper.Map<TaskDto>(created);
    }

    public async Task UpdateAsync(TaskDto taskDto)
    {
        var task = _mapper.Map<TaskItem>(taskDto);
        await _taskRepository.UpdateAsync(task);
    }

    public async Task DeleteAsync(int id)
    {
        await _taskRepository.DeleteAsync(id);
    }
}
