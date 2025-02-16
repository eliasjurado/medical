
namespace Medical.Persistence.Repositories.Commands;

public class FiscalUnitCommandRepository : CommandRepository<FiscalUnit, int>, IFiscalUnitCommandRepository
{
    public FiscalUnitCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
