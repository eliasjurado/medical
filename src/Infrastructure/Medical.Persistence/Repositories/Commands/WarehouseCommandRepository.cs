namespace Medical.Persistence.Repositories.Commands
{
    public class WarehouseCommandRepository : CommandRepository<Warehouse, int>, IWarehouseCommandRepository
    {
        public WarehouseCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
