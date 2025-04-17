namespace Medical.Persistence.Repositories.Queries;

public class FiscalTaxQueryRepository : QueryRepository<FiscalTax, int>, IFiscalTaxQueryRepository
{
    public FiscalTaxQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
