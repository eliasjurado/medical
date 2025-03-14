using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.ArticleStock.Commands.AddArticleStock;

public record AddArticleStockCommandRequest(ArticleStockDto item) : IRequest;

public class AddArticleStockCommandHandler : IRequestHandler<AddArticleStockCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddArticleStockCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddArticleStockCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.ArticleStock>(request.item);
        await _command.ArticleStockCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
