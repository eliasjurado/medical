namespace Medical.Application.Features.FiscalClass.Commands.DeleteFiscalClass;

public record DeleteFiscalClassCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalClassCommandHandler : IRequestHandler<DeleteFiscalClassCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalClassCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalClassCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalClassQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalClass)), false);
        }

        item.IsDeleted = true;
        _command.FiscalClassCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
