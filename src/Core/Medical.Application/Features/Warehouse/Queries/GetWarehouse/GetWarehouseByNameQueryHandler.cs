using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Warehouse.Queries.GetWarehouses;

public record GetWarehouseByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetWarehouseByNameQueryHandler : IRequestHandler<GetWarehouseByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetWarehouseByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetWarehouseByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.WarehouseQuery.GetAsync(x => x.Name!.Equals(request.name));
        var dtoItem = _mapper.Map<WarehouseDto>(item);

        return new DataResponse<WarehouseDto>(dtoItem, HttpStatusCodes.OK);
    }
}