using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.ArticleStock.Commands.AddArticleStock;

public record AddArticleStockCommandRequest(ArticleStockDto item) : IRequest;

public class AddArticleStockCommandHandler : IRequestHandler<AddArticleStockCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;

    public AddArticleStockCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query , IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task Handle(AddArticleStockCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.ArticleStock>(request.item);
        await _command.ArticleStockCommand.AddAsync(item);

        var art = await _query.ArticleQuery.GetAsync(x => x.Id == request.item.ArticleId);
        art.Stock += request.item.Quantity;
        _command.ArticleCommand.Update(art);
        await _command.SaveAsync();
    }
}
