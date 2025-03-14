namespace Medical.Persistence.Repositories.Commands;

public class ArticleStockCommandRepository : CommandRepository<ArticleStock, int>, IArticleStockCommandRepository
{
    public ArticleStockCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
