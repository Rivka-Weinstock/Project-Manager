using Models.DTOs;

namespace BusinessLogic.Services.Interfaces;

public interface IStatusService
{
    Task<IEnumerable<StatusDto>> GetAllAsync();
    Task<StatusDto?> GetByIdAsync(int id);
    Task<StatusDto> AddAsync(StatusDto statusDto);
    Task UpdateAsync(StatusDto statusDto);
    Task DeleteAsync(int id);
}
