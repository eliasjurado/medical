namespace Medical.Application.Features.Appointment.Commands.DeleteAppointment;

public record DeleteAppointmentCommandRequest(int id) : IRequest<IResponse>;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteAppointmentCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _query.AppointmentQuery.GetByIdAsync(o => o.Id == request.id);
        if (appointment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Appointment"), false);
        }

        appointment.IsDeleted = true;
        _command.AppointmentCommand.Update(appointment);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
