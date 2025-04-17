namespace Medical.Application.Features.FiscalTax.Commands.DeleteFiscalTax;

public record DeleteFiscalTaxCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalTaxCommandHandler : IRequestHandler<DeleteFiscalTaxCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalTaxCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalTaxCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalTaxQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalTax)), false);
        }

        item.IsDeleted = true;
        _command.FiscalTaxCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
