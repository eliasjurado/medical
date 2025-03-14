using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class SubCategoryProfile : Profile
{
    public SubCategoryProfile()
    {
        CreateMap<SubCategoryDto, SubCategory>().ReverseMap()
            .ForMember(d => d.CategoryName, o => o.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
    }
}
