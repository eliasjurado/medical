using Medical.Domain.Dto.Article;

namespace Medical.Application.MappingProfıles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto, Article>().ReverseMap()
            .ForMember(d => d.BrandName, o => o.MapFrom(src => src.Brand != null ? src.Brand.Name : string.Empty))
            .ForMember(d => d.FiscalProductName, o => o.MapFrom(src => src.FiscalProduct != null ? src.FiscalProduct.Name : string.Empty))
            .ForMember(d => d.FiscalUnitName, o => o.MapFrom(src => src.FiscalUnit != null ? src.FiscalUnit.Name : string.Empty));
    }
}
