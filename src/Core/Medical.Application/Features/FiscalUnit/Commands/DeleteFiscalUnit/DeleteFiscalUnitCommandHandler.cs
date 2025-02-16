namespace Medical.Application.Features.FiscalUnit.Commands.DeleteFiscalUnit;

public record DeleteFiscalUnitCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalUnitCommandHandler : IRequestHandler<DeleteFiscalUnitCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalUnitCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalUnitCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalUnitQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalUnit)), false);
        }

        item.IsDeleted = true;
        _command.FiscalUnitCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
