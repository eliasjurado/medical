namespace Medical.Persistence.Repositories.Commands
{
    public class ClientCommandRepository : CommandRepository<Client, int>, IClientCommandRepository
    {
        public ClientCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
