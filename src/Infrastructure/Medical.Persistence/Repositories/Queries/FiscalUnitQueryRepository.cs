namespace Medical.Persistence.Repositories.Queries;

public class FiscalUnitQueryRepository : QueryRepository<FiscalUnit, int>, IFiscalUnitQueryRepository
{
    public FiscalUnitQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
