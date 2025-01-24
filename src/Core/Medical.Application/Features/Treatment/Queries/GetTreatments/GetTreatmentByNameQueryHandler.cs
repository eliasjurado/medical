
using Medical.Domain.Dto.Treatment;

namespace Medical.Application.Features.Treatment.Queries.GetTreatments;

public record GetTreatmentByNameQueryRequest(string name) : IRequest<IResponse>;
public class GetTreatmentByNameQueryHandler : IRequestHandler<GetTreatmentByNameQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetTreatmentByNameQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<IResponse> Handle(GetTreatmentByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var treatment = await _query.TreatmentQuery.GetAsync(x => x.Name.Equals(request.name));
        var treatmentDto = _mapper.Map<TreatmentDto>(treatment);

        return new DataResponse<TreatmentDto>(treatmentDto, HttpStatusCodes.OK);
    }
}
