
namespace Medical.Persistence.Repositories.Commands;

public class FiscalTaxCommandRepository : CommandRepository<FiscalTax, int>, IFiscalTaxCommandRepository
{
    public FiscalTaxCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
