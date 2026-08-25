using Models.Entities;

namespace BusinessLogic.Repositories.Interfaces;

public interface IStatusRepository
{
    Task<IEnumerable<Status>> GetAllAsync();
    Task<Status?> GetByIdAsync(int id);
    Task<Status> AddAsync(Status status);
    Task UpdateAsync(Status status);
    Task DeleteAsync(int id);
}
