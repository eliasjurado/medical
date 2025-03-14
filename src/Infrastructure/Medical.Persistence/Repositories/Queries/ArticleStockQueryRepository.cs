namespace Medical.Persistence.Repositories.Queries;

public class ArticleStockQueryRepository : QueryRepository<ArticleStock, int>, IArticleStockQueryRepository
{
    public ArticleStockQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
