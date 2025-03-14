namespace Medical.Persistence.Repositories.Queries;

public class WarehouseQueryRepository : QueryRepository<Warehouse, int>, IWarehouseQueryRepository
{
    public WarehouseQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
