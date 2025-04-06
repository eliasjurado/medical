namespace Medical.Persistence.Repositories.Commands;

public class SaleCommandRepository : CommandRepository<Sale, int>, ISaleCommandRepository
{
    public SaleCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
