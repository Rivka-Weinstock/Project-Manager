using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusesController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusesController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusDto>>> GetAll()
    {
        var statuses = await _statusService.GetAllAsync();
        return Ok(statuses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StatusDto>> GetById(int id)
    {
        var status = await _statusService.GetByIdAsync(id);
        if (status is null)
            return NotFound();

        return Ok(status);
    }

    [HttpPost]
    public async Task<ActionResult<StatusDto>> Create([FromBody] StatusDto statusDto)
    {
        if (string.IsNullOrWhiteSpace(statusDto.Name))
            return BadRequest("Status name is required.");

        var created = await _statusService.AddAsync(statusDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] StatusDto statusDto)
    {
        if (id != statusDto.Id)
            return BadRequest("Route id and body id do not match.");

        if (string.IsNullOrWhiteSpace(statusDto.Name))
            return BadRequest("Status name is required.");

        var existing = await _statusService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _statusService.UpdateAsync(statusDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _statusService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _statusService.DeleteAsync(id);
        return NoContent();
    }
}
