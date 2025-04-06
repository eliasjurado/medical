namespace Medical.Persistence.Repositories.Commands;

public class SaleArticleCommandRepository : CommandRepository<SaleArticle, int>, ISaleArticleCommandRepository
{
    public SaleArticleCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
