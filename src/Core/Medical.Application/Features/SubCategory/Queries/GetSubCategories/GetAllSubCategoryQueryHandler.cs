using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.SubCategory.Queries.GetSubCategories;

public record GetAllSubCategoryQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllSubCategoryQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllSubCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<SubCategoryDto>();

        if (request.forAdmin)
        {
            var list = await _query.SubCategoryQuery.GetAllWithIncludeAsync(false, includes: [x => x.Category!]);
            dtoList = _mapper.Map<List<SubCategoryDto>>(list).ToList();
        }
        else
        {
            var list = await _query.SubCategoryQuery.GetAllWithIncludeAsync(false, cat => cat.IsActive, includes: [x => x.Category!]);
            dtoList = _mapper.Map<List<SubCategoryDto>>(list).ToList();
        }

        return new DataResponse<List<SubCategoryDto>>(dtoList, HttpStatusCodes.OK);
    }
}
