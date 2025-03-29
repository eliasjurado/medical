using Medical.Domain.Dto.Person;

namespace Medical.Application.Features.Client.Queries.GetClients;
public record GetClientByFullNameQueryRequest(string fullName) : IRequest<IResponse>;
public class GetClientByFullNameQueryHandler : IRequestHandler<GetClientByFullNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetClientByFullNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetClientByFullNameQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ClientQuery.GetAsync(x => x.FullName!.Equals(request.fullName));
        var itemDto = _mapper.Map<ClientDto>(item);

        return new DataResponse<ClientDto>(itemDto, HttpStatusCodes.OK);
    }
}
