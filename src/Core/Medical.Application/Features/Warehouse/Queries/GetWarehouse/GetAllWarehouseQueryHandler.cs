using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Warehouse.Queries.GetWarehouses;

public record GetAllWarehouseQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllWarehouseQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllWarehouseQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<WarehouseDto>();

        if (request.forAdmin)
        {
            var list = await _query.WarehouseQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<WarehouseDto>>(list).ToList();
        }
        else
        {
            var list = await _query.WarehouseQuery.GetAllWithIncludeAsync(false, o => o.IsActive);
            dtoList = _mapper.Map<List<WarehouseDto>>(list).ToList();
        }

        return new DataResponse<List<WarehouseDto>>(dtoList, HttpStatusCodes.OK);
    }
}
