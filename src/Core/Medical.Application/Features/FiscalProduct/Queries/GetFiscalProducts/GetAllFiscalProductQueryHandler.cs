using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalProduct.Queries.GetFiscalProducts;

public record GetAllFiscalProductQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalProductQueryHandler : IRequestHandler<GetAllFiscalProductQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalProductQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalProductQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalProductDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalProductQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalProductDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalProductQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalProductDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalProductDto>>(dtoList, HttpStatusCodes.OK);
    }
}
