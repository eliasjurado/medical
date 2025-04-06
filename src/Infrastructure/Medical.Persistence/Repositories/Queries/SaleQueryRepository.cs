namespace Medical.Persistence.Repositories.Queries;

public class SaleQueryRepository : QueryRepository<Sale, int>, ISaleQueryRepository
{
    public SaleQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
