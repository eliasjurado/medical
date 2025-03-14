using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.SubCategory.Queries.GetSubCategories;

public record GetSubCategoryByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetSubCategoryByNameQueryHandler : IRequestHandler<GetSubCategoryByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetSubCategoryByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetSubCategoryByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.SubCategoryQuery.GetAsync(x => x.Name!.Equals(request.name));
        var dtoItem = _mapper.Map<SubCategoryDto>(item);

        return new DataResponse<SubCategoryDto>(dtoItem, HttpStatusCodes.OK);
    }
}