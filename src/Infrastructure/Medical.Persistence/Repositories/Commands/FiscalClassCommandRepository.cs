
namespace Medical.Persistence.Repositories.Commands;

public class FiscalClassCommandRepository : CommandRepository<FiscalClass, int>, IFiscalClassCommandRepository
{
    public FiscalClassCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
