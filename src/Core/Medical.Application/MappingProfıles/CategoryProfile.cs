using Medical.Domain.Dto.Category;

namespace Medical.Application.MappingProfıles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
