using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Article.Commands.AddArticle;

public record AddArticleCommandRequest(ArticleDto item) : IRequest;

public class AddArticleCommandHandler : IRequestHandler<AddArticleCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddArticleCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddArticleCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Article>(request.item);
        await _command.ArticleCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
