using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task is null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create([FromBody] TaskDto taskDto)
    {
        if (string.IsNullOrWhiteSpace(taskDto.Title))
            return BadRequest("Task title is required.");

        var created = await _taskService.AddAsync(taskDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskDto taskDto)
    {
        if (id != taskDto.Id)
            return BadRequest("Route id and body id do not match.");

        if (string.IsNullOrWhiteSpace(taskDto.Title))
            return BadRequest("Task title is required.");

        var existing = await _taskService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _taskService.UpdateAsync(taskDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _taskService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _taskService.DeleteAsync(id);
        return NoContent();
    }
}
