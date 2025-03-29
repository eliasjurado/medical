namespace Medical.Persistence.Repositories.Queries;

public class ClientQueryRepository : QueryRepository<Client, int>, IClientQueryRepository
{
    public ClientQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
