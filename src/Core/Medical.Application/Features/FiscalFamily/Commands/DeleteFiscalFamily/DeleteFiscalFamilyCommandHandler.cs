namespace Medical.Application.Features.FiscalFamily.Commands.DeleteFiscalFamily;

public record DeleteFiscalFamilyCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalFamilyCommandHandler : IRequestHandler<DeleteFiscalFamilyCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalFamilyCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalFamilyCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalFamilyQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalFamily)), false);
        }

        item.IsDeleted = true;
        _command.FiscalFamilyCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
