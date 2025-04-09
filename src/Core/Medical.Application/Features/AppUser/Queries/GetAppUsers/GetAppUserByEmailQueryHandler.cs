using Medical.Domain.Dto.User;

namespace Medical.Application.Features.AppUser.Queries.GetAppUsers;

public record GetAppUserByEmailQueryRequest(string email) : IRequest<IResponse>;
public class GetAppUserByEmailQueryHandler : IRequestHandler<GetAppUserByEmailQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAppUserByEmailQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetAppUserByEmailQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.AppUserQuery.GetAsync(x => x.Email == request.email);

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
