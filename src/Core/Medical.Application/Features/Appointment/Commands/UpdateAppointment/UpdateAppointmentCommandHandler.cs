namespace Medical.Application.Features.Appointment.Commands.UpdateAppointment;

public record UpdateAppointmentCommandRequest(AppointmentDto appointment) : IRequest<IResponse>;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateAppointmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _query.AppointmentQuery.GetByIdAsync(o => o.Id == request.appointment.Id);
        if (appointment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Appointment"), false);
        }

        appointment = _mapper.Map<Domain.Entities.Appointment>(request.appointment);

        if (appointment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Appointment"), false);
        }

        _command.AppointmentCommand.Update(appointment);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
