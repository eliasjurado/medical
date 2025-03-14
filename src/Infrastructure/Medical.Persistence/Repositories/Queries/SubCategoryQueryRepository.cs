namespace Medical.Persistence.Repositories.Queries;

public class SubCategoryQueryRepository : QueryRepository<SubCategory, int>, ISubCategoryQueryRepository
{
    public SubCategoryQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
