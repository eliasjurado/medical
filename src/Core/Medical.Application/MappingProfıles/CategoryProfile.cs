using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
