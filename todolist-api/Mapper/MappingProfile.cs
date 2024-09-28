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
        }
    }
}
