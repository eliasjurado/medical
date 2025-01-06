using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Specialist;
using Medical.Resource;

namespace Medical.Application.Features.Specialist.Queries.GetSpecialists;

public record GetAllSpecialistQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllSpecialistQueryHandler : IRequestHandler<GetAllSpecialistQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllSpecialistQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllSpecialistQueryRequest request, CancellationToken cancellationToken)
    {
        var specialistList = new List<SpecialistDto>();

        if (request.forAdmin)
        {
            var specialists = await _query.SpecialistQuery.GetAllAsync(false);
            specialistList = _mapper.Map<List<SpecialistDto>>(specialists).ToList();
        }
        else
        {
            var specialists = await _query.SpecialistQuery.GetAllWithIncludeAsync(false, o => o.IsActive);
            specialistList = _mapper.Map<List<SpecialistDto>>(specialists).ToList();
        }

        return new DataResponse<List<SpecialistDto>>(specialistList, HttpStatusCodes.OK);
    }
}
