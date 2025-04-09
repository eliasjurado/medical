namespace Medical.Application.Features.Serie.Commands.DeleteSerie;

public record DeleteSerieCommandRequest(int id) : IRequest<IResponse>;

public class DeleteSerieCommandHandler : IRequestHandler<DeleteSerieCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteSerieCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteSerieCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.SerieQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Serie)), false);
        }

        item.IsDeleted = true;
        _command.SerieCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
