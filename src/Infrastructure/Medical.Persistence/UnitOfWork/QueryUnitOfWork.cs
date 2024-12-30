namespace Medical.Persistence.UnitOfWork;

public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly PersistenceDataContext _context;

    public QueryUnitOfWork(PersistenceDataContext context)
    {
        _context = context;
    }

    public CategoryQueryRepository _categoryQuery;
    public PacientQueryRepository _pacientQuery;

    public ICategoryQueryRepository CategoryQuery => _categoryQuery ?? (_categoryQuery = new CategoryQueryRepository(_context));

    public IPacientQueryRepository PacientQuery => _pacientQuery ?? (_pacientQuery = new PacientQueryRepository(_context));
}
