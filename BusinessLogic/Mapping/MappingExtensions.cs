using Models.DTOs;
using Models.Entities;

namespace BusinessLogic.Mapping;

public static class MappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public static User ToEntity(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email
        };
    }

    public static ProjectDto ToDto(this Project project)
    {
        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            UserId = project.UserId
        };
    }

    public static Project ToEntity(this ProjectDto projectDto)
    {
        return new Project
        {
            Id = projectDto.Id,
            Name = projectDto.Name,
            Description = projectDto.Description,
            UserId = projectDto.UserId
        };
    }

    public static TaskDto ToDto(this TaskItem task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            StatusId = task.StatusId,
            ProjectId = task.ProjectId
        };
    }

    public static TaskItem ToEntity(this TaskDto taskDto)
    {
        return new TaskItem
        {
            Id = taskDto.Id,
            Title = taskDto.Title,
            Description = taskDto.Description,
            DueDate = taskDto.DueDate,
            StatusId = taskDto.StatusId,
            ProjectId = taskDto.ProjectId
        };
    }

    public static StatusDto ToDto(this Status status)
    {
        return new StatusDto
        {
            Id = status.Id,
            Name = status.Name
        };
    }

    public static Status ToEntity(this StatusDto statusDto)
    {
        return new Status
        {
            Id = statusDto.Id,
            Name = statusDto.Name
        };
    }
}
