using Models.DTOs;

namespace BusinessLogic.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetAllAsync();
    Task<TaskDto?> GetByIdAsync(int id);
    Task<TaskDto> AddAsync(TaskDto taskDto);
    Task UpdateAsync(TaskDto taskDto);
    Task DeleteAsync(int id);
}
