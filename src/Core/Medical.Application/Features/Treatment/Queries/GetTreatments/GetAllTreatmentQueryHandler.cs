using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Treatment;
using Medical.Resource;

namespace Medical.Application.Features.Treatment.Queries.GetTreatments;

public record GetAllTreatmentQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllTreatmentQueryHandler : IRequestHandler<GetAllTreatmentQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllTreatmentQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllTreatmentQueryRequest request, CancellationToken cancellationToken)
    {
        var treatmentList = new List<TreatmentDto>();

        if (request.forAdmin)
        {
            var treatments = await _query.TreatmentQuery.GetAllAsync(false);
            treatmentList = _mapper.Map<List<TreatmentDto>>(treatments).ToList();
        }
        else
        {
            var treatments = await _query.TreatmentQuery.GetAllWithIncludeAsync(false, o => o.IsActive);
            treatmentList = _mapper.Map<List<TreatmentDto>>(treatments).ToList();
        }

        return new DataResponse<List<TreatmentDto>>(treatmentList, HttpStatusCodes.OK);
    }
}
