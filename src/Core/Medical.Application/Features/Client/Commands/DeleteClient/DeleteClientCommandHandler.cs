namespace Medical.Application.Features.Client.Commands.DeleteClient;
public record DeleteClientCommandRequest(int id) : IRequest<IResponse>;
public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteClientCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteClientCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ClientQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, String.Format(Messages.NotFound, "Client"), false);
        }

        item.IsDeleted = true;
        _command.ClientCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}

