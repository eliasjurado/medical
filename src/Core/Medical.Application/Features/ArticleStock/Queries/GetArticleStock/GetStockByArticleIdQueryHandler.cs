namespace Medical.Application.Features.ArticleStock.Queries.GetArticleStock;

public record GetStockByArticleIdQueryRequest(int id) : IRequest<IResponse>;
public class GetStockByArticleIdQueryHandler : IRequestHandler<GetStockByArticleIdQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetStockByArticleIdQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetStockByArticleIdQueryRequest request, CancellationToken cancellationToken)
    {
        var list = await _query.ArticleStockQuery.GetAllWithIncludeAsync(false, o => o.IsActive && o.ArticleId == request.id);

        var quantity = 0m;
        if (list.Any())
        {
            quantity = list.Sum(x => x.Quantity);
        }

        return new DataResponse<decimal>(quantity, HttpStatusCodes.OK);
    }
}
