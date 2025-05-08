using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.ArticleStockService;

public interface IArticleStockService
{
    event Action OnChange;
    List<ArticleStockDto> ArticleStocks { get; set; }
    List<ArticleStockDto> AdminArticleStocks { get; set; }
    Task<decimal> GetStockByArticleId(int itemId);
    Task GetArticleStocks();
    Task GetAdminArticleStocks();
    Task AddArticleStock(ArticleStockDto item);
    Task UpdateArticleStock(ArticleStockDto item);
    Task DeleteArticleStock(int itemId);
    ArticleStockDto CreateNewArticleStock();
}
