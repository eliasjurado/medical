using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Category.Queries.GetCategories;

public record GetAllCategoryQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllCategoryQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<CategoryDto>();

        if (request.forAdmin)
        {
            var list = await _query.CategoryQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<CategoryDto>>(list).ToList();
        }
        else
        {
            var list = await _query.CategoryQuery.GetAllWithIncludeAsync(false, o => o.IsActive);
            dtoList = _mapper.Map<List<CategoryDto>>(list).ToList();
        }

        return new DataResponse<List<CategoryDto>>(dtoList, HttpStatusCodes.OK);
    }
}
