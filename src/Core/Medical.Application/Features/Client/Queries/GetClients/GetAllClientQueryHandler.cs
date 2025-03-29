using Medical.Domain.Dto.Person;

namespace Medical.Application.Features.Client.Queries.GetClients;

public record GetAllClientQueryRequest(bool forAdmin = false) : IRequest<IResponse>;
public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllClientQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetAllClientQueryRequest request, CancellationToken cancellationToken)
    {
        var itemDtos = new List<ClientDto>();

        if (request.forAdmin)
        {
            var items = await _query.ClientQuery.GetAllAsync(false);
            itemDtos = _mapper.Map<List<ClientDto>>(items).ToList();
        }
        else
        {
            var items = await _query.ClientQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            itemDtos = _mapper.Map<List<ClientDto>>(items).ToList();
        }

        return new DataResponse<List<ClientDto>>(itemDtos, HttpStatusCodes.OK);
    }
}

