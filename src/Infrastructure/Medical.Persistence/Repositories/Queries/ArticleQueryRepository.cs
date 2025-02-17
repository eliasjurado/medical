namespace Medical.Persistence.Repositories.Queries;

public class ArticleQueryRepository : QueryRepository<Article, int>, IArticleQueryRepository
{
    public ArticleQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
