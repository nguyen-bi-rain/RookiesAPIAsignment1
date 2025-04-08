using Application.DTOs;
using Application.DTOs.Person;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //mapping for todo
        CreateMap<TodoCreateDTO, Todo>().ReverseMap();
        CreateMap<TodoCreateDTO, TodoDTO>().ReverseMap();
        CreateMap<TodoUpdateDTO, Todo>().ReverseMap();
        CreateMap<Todo, TodoDTO>().ReverseMap();
        CreateMap<TodoCreateDTO, List<Todo>>().ReverseMap();
        CreateMap<BulkDeleteTaskDTO, List<Guid>>().ReverseMap();
        //mapping for person
        CreateMap<Person, PersonCreateDTO>().ReverseMap();
        CreateMap<PersonUpdateDTO, Person>().ReverseMap();
        CreateMap<Person, PersonDTO>().ReverseMap();
    }
}