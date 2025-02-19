using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalUnit.Queries.GetFiscalUnits;

public record GetFiscalUnitByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetFiscalUnitByNameQueryHandler : IRequestHandler<GetFiscalUnitByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetFiscalUnitByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetFiscalUnitByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalUnitQuery.GetAsync(x => x.Name!.Equals(request.name));
        var dtoItem = _mapper.Map<FiscalUnitDto>(item);

        return new DataResponse<FiscalUnitDto>(dtoItem, HttpStatusCodes.OK);
    }
}
