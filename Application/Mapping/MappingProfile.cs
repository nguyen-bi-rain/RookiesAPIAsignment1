using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TodoCreateDTO, Todo>().ReverseMap();
        CreateMap<TodoCreateDTO, TodoDTO>().ReverseMap();
        CreateMap<TodoUpdateDTO, Todo>().ReverseMap();
        CreateMap<Todo, TodoDTO>().ReverseMap();
        CreateMap<TodoCreateDTO, List<Todo>>().ReverseMap();
        CreateMap<BulkDeleteTaskDTO, List<Guid>>().ReverseMap();
    }
}