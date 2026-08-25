using BusinessLogic.Mapping;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;

namespace BusinessLogic.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(task => task.ToDto());
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task?.ToDto();
    }

    public async Task<TaskDto> AddAsync(TaskDto taskDto)
    {
        var task = taskDto.ToEntity();
        var created = await _taskRepository.AddAsync(task);
        return created.ToDto();
    }

    public async Task UpdateAsync(TaskDto taskDto)
    {
        var task = taskDto.ToEntity();
        await _taskRepository.UpdateAsync(task);
    }

    public async Task DeleteAsync(int id)
    {
        await _taskRepository.DeleteAsync(id);
    }
}
