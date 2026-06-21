using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace Api.Profiles;

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
