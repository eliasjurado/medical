namespace Medical.Application.Features.Appointment.Queries.GetAppointments;

public record GetAllAppointmentQueryRequest(bool forAdmin = false) : IRequest<IResponse>;

public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQueryRequest, IResponse>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public GetAllAppointmentQueryHandler(IQueryUnitOfWork query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(GetAllAppointmentQueryRequest request, CancellationToken cancellationToken)
    {
        var appointmentList = new List<AppointmentDto>();

        if (request.forAdmin)
        {
            var appointments = await _query.AppointmentQuery.GetAllWithIncludeAsync(false, includes: [x => x.Pacient!, y => y.Treatment!, z => z.Specialist!]);
            appointmentList = _mapper.Map<List<AppointmentDto>>(appointments).ToList();
        }
        else
        {

            var appointments = await _query.AppointmentQuery.GetAllWithIncludeAsync(false, o => o.IsActive, includes: [x => x.Pacient!, y => y.Treatment!, z => z.Specialist!]);
            appointmentList = _mapper.Map<List<AppointmentDto>>(appointments).ToList();
        }

        return new DataResponse<List<AppointmentDto>>(appointmentList, HttpStatusCodes.OK);
    }
}
