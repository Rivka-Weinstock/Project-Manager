using BusinessLogic.Mapping;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Models.DTOs;

namespace BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => user.ToDto());
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user?.ToDto();
    }

    public async Task<UserDto> AddAsync(UserDto userDto)
    {
        var user = userDto.ToEntity();
        var created = await _userRepository.AddAsync(user);
        return created.ToDto();
    }

    public async Task UpdateAsync(UserDto userDto)
    {
        var user = userDto.ToEntity();
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }
}
