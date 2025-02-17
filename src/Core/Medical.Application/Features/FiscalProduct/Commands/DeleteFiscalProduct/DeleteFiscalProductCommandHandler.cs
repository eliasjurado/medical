namespace Medical.Application.Features.FiscalProduct.Commands.DeleteFiscalProduct;

public record DeleteFiscalProductCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalProductCommandHandler : IRequestHandler<DeleteFiscalProductCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalProductCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalProductCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalProductQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalProduct)), false);
        }

        item.IsDeleted = true;
        _command.FiscalProductCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
