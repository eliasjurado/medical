using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Serie.Queries.GetSeries;

public record GetAllSerieQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllSerieQueryHandler : IRequestHandler<GetAllSerieQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllSerieQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllSerieQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<SerieDto>();

        if (request.forAdmin)
        {
            var list = await _query.SerieQuery.GetAllWithIncludeAsync(false, includes: [x => x.AppUser!]);
            dtoList = _mapper.Map<List<SerieDto>>(list).ToList();
        }
        else
        {
            var list = await _query.SerieQuery.GetAllWithIncludeAsync(false, i => i.IsActive, includes:[x=>x.AppUser!]);
            dtoList = _mapper.Map<List<SerieDto>>(list).ToList();
        }

        return new DataResponse<List<SerieDto>>(dtoList, HttpStatusCodes.OK);
    }
}
