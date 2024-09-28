using AutoMapper;
using todolist_api.Dto;
using todolist_api.Models;

namespace todolist_api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTodoTaskDto, TodoTask>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore());

            CreateMap<UpdateTodoTaskDto, TodoTask>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for the update mapping
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore CreatedAt
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore()); // Ignore UpdateAt
        }
    }
}
