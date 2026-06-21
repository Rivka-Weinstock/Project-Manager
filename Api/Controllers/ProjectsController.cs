using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetById(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create([FromBody] ProjectDto projectDto)
    {
        if (string.IsNullOrWhiteSpace(projectDto.Name))
            return BadRequest("Project name is required.");

        var created = await _projectService.AddAsync(projectDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projectDto)
    {
        if (id != projectDto.Id)
            return BadRequest("Route id and body id do not match.");

        if (string.IsNullOrWhiteSpace(projectDto.Name))
            return BadRequest("Project name is required.");

        var existing = await _projectService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _projectService.UpdateAsync(projectDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _projectService.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        await _projectService.DeleteAsync(id);
        return NoContent();
    }
}
