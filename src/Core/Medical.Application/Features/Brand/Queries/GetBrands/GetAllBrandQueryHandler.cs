using Medical.Domain.Dto.Brand;

namespace Medical.Application.Features.Brand.Queries.GetBrands;

public record GetAllBrandQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllBrandQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<BrandDto>();

        if (request.forAdmin)
        {
            var list = await _query.BrandQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<BrandDto>>(list).ToList();
        }
        else
        {
            var list = await _query.BrandQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<BrandDto>>(list).ToList();
        }

        return new DataResponse<List<BrandDto>>(dtoList, HttpStatusCodes.OK);
    }
}
