namespace Medical.Persistence.Repositories.Commands
{
    public class PacientCommandRepository : CommandRepository<Pacient, int>, IPacientCommandRepository
    {
        public PacientCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
