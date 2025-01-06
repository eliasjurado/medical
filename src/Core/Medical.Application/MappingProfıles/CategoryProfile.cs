using AutoMapper;
using Medical.Domain.Dto.Category;
using Medical.Domain.Entities;

namespace Medical.Application.MappingProfıles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
