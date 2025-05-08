using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Sale.Queries.GetSales;

public record GetAllSaleQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllSaleQueryHandler : IRequestHandler<GetAllSaleQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllSaleQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllSaleQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<SaleDto>();

        if (request.forAdmin)
        {
            var list = await _query.SaleQuery.GetAllWithIncludeAsync(false);
            dtoList = _mapper.Map<List<SaleDto>>(list).ToList();
        }
        else
        {
            var list = await _query.SaleQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<SaleDto>>(list).ToList();
        }

        return new DataResponse<List<SaleDto>>(dtoList, HttpStatusCodes.OK);
    }
}
