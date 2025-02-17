
namespace Medical.Persistence.Repositories.Commands;

public class FiscalSegmentCommandRepository : CommandRepository<FiscalSegment, int>, IFiscalSegmentCommandRepository
{
    public FiscalSegmentCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
