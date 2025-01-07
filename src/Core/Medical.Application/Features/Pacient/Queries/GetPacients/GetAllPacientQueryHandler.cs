using Medical.Domain.Dto.Pacient;

namespace Medical.Application.Features.Pacient.Queries.GetPacients;

public record GetAllPacientQueryRequest(bool forAdmin = false) : IRequest<IResponse>;
public class GetAllPacientQueryHandler : IRequestHandler<GetAllPacientQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllPacientQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetAllPacientQueryRequest request, CancellationToken cancellationToken)
    {
        var pacientList = new List<PacientDto>();

        if (request.forAdmin)
        {
            var pacients = await _query.PacientQuery.GetAllAsync(false);
            pacientList = _mapper.Map<List<PacientDto>>(pacients).ToList();
        }
        else
        {
            var pacients = await _query.PacientQuery.GetAllWithIncludeAsync(false, i => i.IsActive);
            pacientList = _mapper.Map<List<PacientDto>>(pacients).ToList();
        }

        return new DataResponse<List<PacientDto>>(pacientList, HttpStatusCodes.OK);
    }
}

