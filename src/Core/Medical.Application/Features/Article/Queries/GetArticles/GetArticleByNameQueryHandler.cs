using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Article.Queries.GetArticles
{
    public record GetArticleByNameQueryRequest(string name) : IRequest<IResponse>;
    public class GetArticleByNameQueryHandler : IRequestHandler<GetArticleByNameQueryRequest, IResponse>
    {
        private readonly IQueryUnitOfWork _query;
        private readonly IMapper _mapper;

        public GetArticleByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<IResponse> Handle(GetArticleByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _query.ArticleQuery.GetWithIncludeAsync(false, x => x.Name!.Equals(request.name), includes: [x => x.FiscalProduct!, y => y.Brand!, z => z.FiscalUnit!, v => v.SubCategory!]);
            var dtoItem = _mapper.Map<ArticleDto>(item);

            return new DataResponse<ArticleDto>(dtoItem, HttpStatusCodes.OK);
        }
    }
}
