using AutoMapper;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;
using Models.Entities;

namespace BusinessLogic.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;
    private readonly IMapper _mapper;

    public StatusService(IStatusRepository statusRepository, IMapper mapper)
    {
        _statusRepository = statusRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StatusDto>> GetAllAsync()
    {
        var statuses = await _statusRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StatusDto>>(statuses);
    }

    public async Task<StatusDto?> GetByIdAsync(int id)
    {
        var status = await _statusRepository.GetByIdAsync(id);
        return status is null ? null : _mapper.Map<StatusDto>(status);
    }

    public async Task<StatusDto> AddAsync(StatusDto statusDto)
    {
        var status = _mapper.Map<Status>(statusDto);
        var created = await _statusRepository.AddAsync(status);
        return _mapper.Map<StatusDto>(created);
    }

    public async Task UpdateAsync(StatusDto statusDto)
    {
        var status = _mapper.Map<Status>(statusDto);
        await _statusRepository.UpdateAsync(status);
    }

    public async Task DeleteAsync(int id)
    {
        await _statusRepository.DeleteAsync(id);
    }
}
