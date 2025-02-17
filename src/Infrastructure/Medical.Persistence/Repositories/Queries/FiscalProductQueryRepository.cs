namespace Medical.Persistence.Repositories.Queries;

public class FiscalProductQueryRepository : QueryRepository<FiscalProduct, int>, IFiscalProductQueryRepository
{
    public FiscalProductQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
