
namespace Medical.Persistence.Repositories.Commands;

public class FiscalProductCommandRepository : CommandRepository<FiscalProduct, int>, IFiscalProductCommandRepository
{
    public FiscalProductCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
