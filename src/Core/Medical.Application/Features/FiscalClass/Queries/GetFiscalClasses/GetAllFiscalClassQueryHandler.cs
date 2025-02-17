using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalClass.Queries.GetFiscalClasses;

public record GetAllFiscalClassQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllFiscalClassQueryHandler : IRequestHandler<GetAllFiscalClassQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllFiscalClassQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllFiscalClassQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<FiscalClassDto>();

        if (request.forAdmin)
        {
            var list = await _query.FiscalClassQuery.GetAllAsync(false);
            dtoList = _mapper.Map<List<FiscalClassDto>>(list).ToList();
        }
        else
        {
            var list = await _query.FiscalClassQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            dtoList = _mapper.Map<List<FiscalClassDto>>(list).ToList();
        }

        return new DataResponse<List<FiscalClassDto>>(dtoList, HttpStatusCodes.OK);
    }
}
