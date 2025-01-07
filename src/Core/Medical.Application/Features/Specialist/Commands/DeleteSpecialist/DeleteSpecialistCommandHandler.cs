namespace Medical.Application.Features.Specialist.Commands.DeleteSpecialist;

public record DeleteSpecialistCommandRequest(int id) : IRequest<IResponse>;

public class DeleteSpecialistCommandHandler : IRequestHandler<DeleteSpecialistCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteSpecialistCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteSpecialistCommandRequest request, CancellationToken cancellationToken)
    {
        var specialist = await _query.SpecialistQuery.GetByIdAsync(o => o.Id == request.id);
        if (specialist == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Specialist"), false);
        }

        specialist.IsDeleted = true;
        _command.SpecialistCommand.Update(specialist);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
