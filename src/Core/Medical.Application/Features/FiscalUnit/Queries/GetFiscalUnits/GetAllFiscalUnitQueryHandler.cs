using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalUnit.Queries.GetFiscalUnits;

public record GetAllFiscalUnitQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalUnitQueryHandler : IRequestHandler<GetAllFiscalUnitQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalUnitQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalUnitQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalUnitDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalUnitQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalUnitDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalUnitQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalUnitDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalUnitDto>>(dtoList, HttpStatusCodes.OK);
    }
}
