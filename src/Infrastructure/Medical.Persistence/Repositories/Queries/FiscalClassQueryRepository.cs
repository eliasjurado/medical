namespace Medical.Persistence.Repositories.Queries;

public class FiscalClassQueryRepository : QueryRepository<FiscalClass, int>, IFiscalClassQueryRepository
{
    public FiscalClassQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
