using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalSegment.Queries.GetFiscalSegments;

public record GetAllFiscalSegmentQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalSegmentQueryHandler : IRequestHandler<GetAllFiscalSegmentQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalSegmentQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalSegmentQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalSegmentDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalSegmentQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalSegmentDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalSegmentQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalSegmentDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalSegmentDto>>(dtoList, HttpStatusCodes.OK);
    }
}
