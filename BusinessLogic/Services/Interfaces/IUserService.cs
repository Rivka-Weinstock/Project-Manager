using Models.DTOs;

namespace BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> AddAsync(UserDto userDto);
    Task UpdateAsync(UserDto userDto);
    Task DeleteAsync(int id);
}
