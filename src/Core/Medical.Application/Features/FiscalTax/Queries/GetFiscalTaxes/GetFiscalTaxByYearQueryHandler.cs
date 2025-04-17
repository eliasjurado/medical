using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalTax.Queries.GetFiscalTaxes;

public record GetFiscalTaxByYearQueryRequest(int year) : IRequest<IResponse>;
public class GetFiscalTaxByYearQueryHandler : IRequestHandler<GetFiscalTaxByYearQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetFiscalTaxByYearQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetFiscalTaxByYearQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalTaxQuery.GetAsync(x => x.NumYear!.Equals(request.year));

        if (item == null)
        {
            return new DataResponse<FiscalTaxDto>(null, HttpStatusCodes.OK);
        }

        var dtoItem = _mapper.Map<FiscalTaxDto>(item);

        return new DataResponse<FiscalTaxDto>(dtoItem, HttpStatusCodes.OK);
    }
}
