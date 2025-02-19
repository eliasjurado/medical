using Medical.Domain.Dto.Brand;

namespace Medical.Application.Features.Brand.Queries.GetBrands
{
    public record GetBrandByNameQueryRequest(string name) : IRequest<IResponse>;
    public class GetBrandByNameQueryHandler : IRequestHandler<GetBrandByNameQueryRequest, IResponse>
    {
        private readonly IQueryUnitOfWork _query;
        private readonly IMapper _mapper;

        public GetBrandByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<IResponse> Handle(GetBrandByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _query.BrandQuery.GetAsync(x => x.Name!.Equals(request.name));
            var dtoItem = _mapper.Map<BrandDto>(item);

            return new DataResponse<BrandDto>(dtoItem, HttpStatusCodes.OK);
        }
    }
}
