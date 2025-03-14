namespace Medical.Application.Features.Warehouse.Commands.DeleteWarehouse;

public record DeleteWarehouseCommandRequest(int id) : IRequest<IResponse>;

public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteWarehouseCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteWarehouseCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.WarehouseQuery.GetByIdAsync(o => o.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, String.Format(Messages.NotFound, "Warehouse"), false);
        }

        item.IsDeleted = true;
        _command.WarehouseCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
