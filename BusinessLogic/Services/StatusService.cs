using BusinessLogic.Mapping;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;

namespace BusinessLogic.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task<IEnumerable<StatusDto>> GetAllAsync()
    {
        var statuses = await _statusRepository.GetAllAsync();
        return statuses.Select(status => status.ToDto());
    }

    public async Task<StatusDto?> GetByIdAsync(int id)
    {
        var status = await _statusRepository.GetByIdAsync(id);
        return status?.ToDto();
    }

    public async Task<StatusDto> AddAsync(StatusDto statusDto)
    {
        var status = statusDto.ToEntity();
        var created = await _statusRepository.AddAsync(status);
        return created.ToDto();
    }

    public async Task UpdateAsync(StatusDto statusDto)
    {
        var status = statusDto.ToEntity();
        await _statusRepository.UpdateAsync(status);
    }

    public async Task DeleteAsync(int id)
    {
        await _statusRepository.DeleteAsync(id);
    }
}
