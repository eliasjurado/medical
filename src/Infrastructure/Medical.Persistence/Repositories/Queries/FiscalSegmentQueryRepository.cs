namespace Medical.Persistence.Repositories.Queries;

public class FiscalSegmentQueryRepository : QueryRepository<FiscalSegment, int>, IFiscalSegmentQueryRepository
{
    public FiscalSegmentQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
