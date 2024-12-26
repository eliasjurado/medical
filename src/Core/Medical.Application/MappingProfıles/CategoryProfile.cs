using Medical.Domain.Entities;
using Medical.Domain.Dto.Category;
using AutoMapper;

namespace Medical.Application.MappingProfıles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
