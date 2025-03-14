using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Category.Queries.GetCategories;

public record GetCategoryByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetCategoryByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetCategoryByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.CategoryQuery.GetAsync(x => x.Name!.Equals(request.name));
        var dtoItem = _mapper.Map<CategoryDto>(item);

        return new DataResponse<CategoryDto>(dtoItem, HttpStatusCodes.OK);
    }
}