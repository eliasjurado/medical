namespace Medical.Persistence.Repositories.Commands;

public class ArticleCommandRepository : CommandRepository<Article, int>, IArticleCommandRepository
{
    public ArticleCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
