namespace Medical.Persistence.Repositories.Queries;

public class FiscalFamilyQueryRepository : QueryRepository<FiscalFamily, int>, IFiscalFamilyQueryRepository
{
    public FiscalFamilyQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
