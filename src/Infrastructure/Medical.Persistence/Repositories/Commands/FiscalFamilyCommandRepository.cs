
namespace Medical.Persistence.Repositories.Commands;

public class FiscalFamilyCommandRepository : CommandRepository<FiscalFamily, int>, IFiscalFamilyCommandRepository
{
    public FiscalFamilyCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
