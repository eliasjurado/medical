using Medical.Application.Contracts.Identity;
using Medical.Domain.Dto.Sales;
using Medical.Domain.Enums;

namespace Medical.Application.Features.Sale.Commands.AddSale;

public record AddSaleCommandRequest(SaleDto item) : IRequest<IResponse>;

public class AddSaleCommandHandler : IRequestHandler<AddSaleCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public AddSaleCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query, ICurrentUser currentUser)
    {
        _command = command;
        _query = query;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<IResponse> Handle(AddSaleCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Sale>(request.item);
        item.UserId = _currentUser.UserId;
        await _command.SaleCommand.AddAsync(item);

        var user = await _query.AppUserQuery.GetAsync(x => x.UserId == item.UserId);
        var serie = await _query.SerieQuery.GetAsync(x => x.AppUserId == user.Id && x.TypeSaleId == item.TypeSaleId && x.NumSerie == int.Parse(item.Serie ?? "0"));
        if (serie != null)
        {
            serie.NumCorrelative++;
            _command.SerieCommand.Update(serie);
        }

        foreach (var saleArticle in item.SaleArticles)
        {
            var stock = new Domain.Entities.ArticleStock
            {
                ArticleId = saleArticle.ArticleId,
                Quantity = saleArticle.Quantity * -1,
                InventoryDateTime = DateTime.Now,
                WarehouseId = 1,
                TypeArticleStockActionId = TypeArticleStockActionId.Sale
            };
            await _command.ArticleStockCommand.AddAsync(stock);

            var art = await _query.ArticleQuery.GetAsync(x => x.Id == stock.ArticleId);
            art.Stock += stock.Quantity;
            _command.ArticleCommand.Update(art);
        }


        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
