using Medical.Domain.Dto.Sales;
using Medical.Domain.Dto.User;

namespace Medical.Application.Features.AppUser.Queries.GetAppUsers;

public record GetAllAppUserQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllAppUserQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllAppUserQueryRequest request, CancellationToken cancellationToken)
    {
        var dtoList = new List<AppUserDto>();

        if (request.forAdmin)
        {
            var list = await _query.AppUserQuery.GetAllWithIncludeAsync(false, includes: [x => x.Series!]);
            dtoList = _mapper.Map<List<AppUserDto>>(list).ToList();
        }
        else
        {
            var list = await _query.AppUserQuery.GetAllWithIncludeAsync(false, o => o.IsActive, includes: [x => x.Series!]);
            dtoList = _mapper.Map<List<AppUserDto>>(list).ToList();
        }

        return new DataResponse<List<AppUserDto>>(dtoList, HttpStatusCodes.OK);
    }
}
