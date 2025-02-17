namespace Medical.Application.Features.FiscalSegment.Commands.DeleteFiscalSegment;

public record DeleteFiscalSegmentCommandRequest(int id) : IRequest<IResponse>;

public class DeleteFiscalSegmentCommandHandler : IRequestHandler<DeleteFiscalSegmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteFiscalSegmentCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteFiscalSegmentCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalSegmentQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalSegment)), false);
        }

        item.IsDeleted = true;
        _command.FiscalSegmentCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
