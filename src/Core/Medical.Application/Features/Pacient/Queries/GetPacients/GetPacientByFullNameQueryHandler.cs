using Medical.Domain.Dto.Person;

namespace Medical.Application.Features.Pacient.Queries.GetPacients;
public record GetPacientByFullNameQueryRequest(string fullName) : IRequest<IResponse>;
public class GetPacientByFullNameQueryHandler : IRequestHandler<GetPacientByFullNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetPacientByFullNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetPacientByFullNameQueryRequest request, CancellationToken cancellationToken)
    {
        var pacient = await _query.PacientQuery.GetAsync(x => x.FullName!.Equals(request.fullName));
        var pacientDto = _mapper.Map<PacientDto>(pacient);

        return new DataResponse<PacientDto>(pacientDto, HttpStatusCodes.OK);
    }
}
