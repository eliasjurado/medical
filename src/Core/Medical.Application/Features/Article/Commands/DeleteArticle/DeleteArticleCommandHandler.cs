namespace Medical.Application.Features.Article.Commands.DeleteArticle;

public record DeleteArticleCommandRequest(int id) : IRequest<IResponse>;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteArticleCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteArticleCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ArticleQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Article)), false);
        }

        item.IsDeleted = true;
        _command.ArticleCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
