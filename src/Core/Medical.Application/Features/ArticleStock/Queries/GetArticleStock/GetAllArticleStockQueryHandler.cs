using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.ArticleStock.Queries.GetArticleStocks;

public record GetAllArticleStockQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllArticleStockQueryHandler : IRequestHandler<GetAllArticleStockQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllArticleStockQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllArticleStockQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<ArticleStockDto>();

        if (request.forAdmin)
        {
            var list = await _query.ArticleStockQuery.GetAllWithIncludeAsync(false, o => o.IsActive, includes: [x => x.Article!, y => y.Warehouse!]);
            dtoList = _mapper.Map<List<ArticleStockDto>>(list).ToList();
        }
        else
        {
            var list = await _query.ArticleStockQuery.GetAllWithIncludeAsync(false, o => o.IsActive, includes: [x => x.Article!, y => y.Warehouse!]);
            dtoList = _mapper.Map<List<ArticleStockDto>>(list).ToList();
        }

        return new DataResponse<List<ArticleStockDto>>(dtoList, HttpStatusCodes.OK);
    }
}
