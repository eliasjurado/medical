namespace Medical.Application.Features.ArticleStock.Commands.DeleteArticleStock;

public record DeleteArticleStockCommandRequest(int id) : IRequest<IResponse>;

public class DeleteArticleStockCommandHandler : IRequestHandler<DeleteArticleStockCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteArticleStockCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteArticleStockCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ArticleStockQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.ArticleStock)), false);
        }

        item.IsDeleted = true;
        _command.ArticleStockCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
