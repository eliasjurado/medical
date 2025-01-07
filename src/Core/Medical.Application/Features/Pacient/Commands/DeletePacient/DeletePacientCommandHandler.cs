namespace Medical.Application.Features.Pacient.Commands.DeletePacient;
public record DeletePacientCommandRequest(int id) : IRequest<IResponse>;
public class DeletePacientCommandHandler : IRequestHandler<DeletePacientCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeletePacientCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeletePacientCommandRequest request, CancellationToken cancellationToken)
    {
        var pacient = await _query.PacientQuery.GetByIdAsync(i => i.Id == request.id);
        if (pacient == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, String.Format(Messages.NotFound, "Pacient"), false);
        }

        pacient.IsDeleted = true;
        _command.PacientCommand.Update(pacient);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}

