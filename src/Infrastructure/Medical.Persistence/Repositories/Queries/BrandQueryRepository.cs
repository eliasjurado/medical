namespace Medical.Persistence.Repositories.Queries;

public class BrandQueryRepository : QueryRepository<Brand, int>, IBrandQueryRepository
{
    public BrandQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
