using Medical.Domain.Dto.User;

namespace Medical.Application.Features.AppUser.Queries.GetAppUsers;

public record GetAppUserByUserIdQueryRequest(string userId) : IRequest<IResponse>;
public class GetAppUserByUserIdQueryHandler : IRequestHandler<GetAppUserByUserIdQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAppUserByUserIdQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetAppUserByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.AppUserQuery.GetAsync(x => x.UserId == request.userId);

        if (item != null)
        {
            var itemDto = _mapper.Map<AppUserDto>(item);
            return new DataResponse<AppUserDto>(itemDto, HttpStatusCodes.OK);
        }
        else
        {
            return new DataResponse<AppUserDto>(null, HttpStatusCodes.OK);
        }

    }
}
