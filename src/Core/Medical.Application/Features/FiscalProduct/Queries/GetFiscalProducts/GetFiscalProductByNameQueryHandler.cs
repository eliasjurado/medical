using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalProduct.Queries.GetFiscalProducts;

public record GetFiscalProductByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetFiscalProductByNameQueryHandler : IRequestHandler<GetFiscalProductByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetFiscalProductByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetFiscalProductByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalProductQuery.GetAsync(x => x.Name!.Equals(request.name));
        var dtoItem = _mapper.Map<FiscalProductDto>(item);

        return new DataResponse<FiscalProductDto>(dtoItem, HttpStatusCodes.OK);
    }
}
