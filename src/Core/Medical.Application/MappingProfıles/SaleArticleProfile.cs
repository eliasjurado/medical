using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class SaleArticleProfile : Profile
{
    public SaleArticleProfile()
    {
        CreateMap<SaleArticleDto, SaleArticle>().ReverseMap()
            .ForMember(d => d.ArticleNetPrice, o => o.MapFrom(src => src.Article != null ? src.Article.NetPrice : 0))
            .ForMember(d => d.ArticleName, o => o.MapFrom(src => src.Article != null ? src.Article.Name : string.Empty));
    }
}
