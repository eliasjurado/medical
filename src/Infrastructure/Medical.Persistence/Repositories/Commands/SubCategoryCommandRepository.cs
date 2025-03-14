namespace Medical.Persistence.Repositories.Commands;

public class SubCategoryCommandRepository : CommandRepository<SubCategory, int>, ISubCategoryCommandRepository
{
    public SubCategoryCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
