using Medical.Domain.Dto.Brand;

namespace Medical.Application.MappingProfıles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandDto>().ReverseMap();
    }
}
