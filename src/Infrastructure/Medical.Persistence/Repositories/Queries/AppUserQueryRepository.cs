namespace Medical.Persistence.Repositories.Queries;

public class AppUserQueryRepository : QueryRepository<AppUser, int>, IAppUserQueryRepository
{
    public AppUserQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
