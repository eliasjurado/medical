using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalTax.Queries.GetFiscalTaxes;

public record GetAllFiscalTaxQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalTaxQueryHandler : IRequestHandler<GetAllFiscalTaxQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalTaxQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalTaxQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalTaxDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalTaxQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalTaxDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalTaxQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalTaxDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalTaxDto>>(dtoList, HttpStatusCodes.OK);
    }
}
