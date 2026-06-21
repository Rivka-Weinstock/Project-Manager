using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] UserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Name))
            return BadRequest("User name is required.");

        if (string.IsNullOrWhiteSpace(userDto.Email))
            return BadRequest("User email is required.");

        var created = await _userService.AddAsync(userDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest("Route id and body id do not match.");

        if (string.IsNullOrWhiteSpace(userDto.Name))
            return BadRequest("User name is required.");

        if (string.IsNullOrWhiteSpace(userDto.Email))
            return BadRequest("User email is required.");

        var existing = await _userService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _userService.UpdateAsync(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _userService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
