using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Serie.Queries.GetSeries
{
    public record GetSeriesByUserIdQueryRequest(string userId) : IRequest<IResponse>;
    public class GetSeriesByUserIdQueryHandler : IRequestHandler<GetSeriesByUserIdQueryRequest, IResponse>
    {
        private readonly IQueryUnitOfWork _query;
        private readonly IMapper _mapper;

        public GetSeriesByUserIdQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<IResponse> Handle(GetSeriesByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _query.SerieQuery.GetAllWithIncludeAsync(false, x => x.AppUser!.UserId == request.userId, includes: [x => x.AppUser!]);

            if (!list.Any())
            {
                return new DataResponse<List<SerieDto>>(null, HttpStatusCodes.OK);
            }
            else
            {
                var dtoItem = _mapper.Map<List<SerieDto>>(list);
                return new DataResponse<List<SerieDto>>(dtoItem, HttpStatusCodes.OK);
            }
        }
    }
}
