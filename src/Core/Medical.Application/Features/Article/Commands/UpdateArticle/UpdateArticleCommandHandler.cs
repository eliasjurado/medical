using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Article.Commands.UpdateArticle;

public record UpdateArticleCommandRequest(ArticleDto item) : IRequest<IResponse>;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateArticleCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateArticleCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ArticleQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Article)), false);
        }

        item = _mapper.Map<Domain.Entities.Article>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Article)), false);
        }

        _command.ArticleCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
