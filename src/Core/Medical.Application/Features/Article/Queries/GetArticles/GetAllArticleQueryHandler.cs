using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Article.Queries.GetArticles;

public record GetAllArticleQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticleQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllArticleQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllArticleQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<ArticleDto>();

        if (request.forAdmin)
        {
            var list = await _query.ArticleQuery.GetAllWithIncludeAsync(false, includes: [x => x.FiscalProduct!, y => y.Brand!, z => z.FiscalUnit!, v => v.SubCategory!]);
            dtoList = _mapper.Map<List<ArticleDto>>(list).ToList();
        }
        else
        {
            var list = await _query.ArticleQuery.GetAllWithIncludeAsync(false, o => o.IsActive, includes: [x => x.FiscalProduct!, y => y.Brand!, z => z.FiscalUnit!, v => v.SubCategory!]);
            dtoList = _mapper.Map<List<ArticleDto>>(list).ToList();
        }

        return new DataResponse<List<ArticleDto>>(dtoList, HttpStatusCodes.OK);
    }
}
