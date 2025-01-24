using Medical.Domain.Dto.Specialist;

namespace Medical.Application.Features.Specialist.Queries.GetSpecialists;

public record GetSpecialistByFullNameQueryRequest(string fullName) : IRequest<IResponse>;
public class GetSpecialistByFullNameQueryHandler : IRequestHandler<GetSpecialistByFullNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetSpecialistByFullNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetSpecialistByFullNameQueryRequest request, CancellationToken cancellationToken)
    {
        var specialist = await _query.SpecialistQuery.GetAsync(x => x.FullName!.Equals(request.fullName));
        var specialistDto = _mapper.Map<SpecialistDto>(specialist);

        return new DataResponse<SpecialistDto>(specialistDto, HttpStatusCodes.OK);
    }
}
