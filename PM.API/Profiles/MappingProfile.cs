using AutoMapper;
using PM.Models.DTOs;
using PM.Models.Entities;

namespace PM.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<TaskItem, TaskDto>().ReverseMap();
        CreateMap<Status, StatusDto>().ReverseMap();
    }
}
