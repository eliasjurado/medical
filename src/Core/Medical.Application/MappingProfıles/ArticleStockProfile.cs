using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class ArticleStockProfile : Profile
{
    public ArticleStockProfile()
    {
        CreateMap<ArticleStockDto, ArticleStock>().ReverseMap()
            .ForMember(d => d.ArticleName, o => o.MapFrom(src => src.Article != null ? src.Article.Name : string.Empty))
            .ForMember(d => d.WarehouseName, o => o.MapFrom(src => src.Warehouse != null ? src.Warehouse.Name : string.Empty));
    }
}
