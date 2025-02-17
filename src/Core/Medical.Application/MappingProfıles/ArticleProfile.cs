using Medical.Domain.Dto.Article;

namespace Medical.Application.MappingProfıles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>().ReverseMap();
    }
}
