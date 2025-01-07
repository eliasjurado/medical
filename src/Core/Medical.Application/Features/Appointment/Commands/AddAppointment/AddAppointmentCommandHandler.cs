namespace Medical.Application.Features.Appointment.Commands.AddAppointment;

public record AddAppointmentCommandRequest(AppointmentDto appointment) : IRequest;

public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddAppointmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var appointment = _mapper.Map<Domain.Entities.Appointment>(request.appointment);
        await _command.AppointmentCommand.AddAsync(appointment);
        await _command.SaveAsync();
    }
}
