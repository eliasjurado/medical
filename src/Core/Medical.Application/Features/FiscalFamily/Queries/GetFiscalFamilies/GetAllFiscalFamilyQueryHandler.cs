using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalFamily.Queries.GetFiscalFamilies;

public record GetAllFiscalFamilyQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalFamilyQueryHandler : IRequestHandler<GetAllFiscalFamilyQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalFamilyQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalFamilyQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalFamilyDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalFamilyQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalFamilyDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalFamilyQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalFamilyDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalFamilyDto>>(dtoList, HttpStatusCodes.OK);
    }
}
