namespace Medical.Persistence.Repositories.Commands;

public class BrandCommandRepository : CommandRepository<Brand, int>, IBrandCommandRepository
{
    public BrandCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
