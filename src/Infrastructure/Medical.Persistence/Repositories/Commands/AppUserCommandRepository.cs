namespace Medical.Persistence.Repositories.Commands;

public class AppUserCommandRepository : CommandRepository<AppUser, int>, IAppUserCommandRepository
{
    public AppUserCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
