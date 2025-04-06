namespace Medical.Persistence.Repositories.Queries;

public class SaleArticleQueryRepository : QueryRepository<SaleArticle, int>, ISaleArticleQueryRepository
{
    public SaleArticleQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
