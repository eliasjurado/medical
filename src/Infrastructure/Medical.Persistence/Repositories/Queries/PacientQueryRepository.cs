namespace Medical.Persistence.Repositories.Queries;

public class PacientQueryRepository : QueryRepository<Pacient, int>, IPacientQueryRepository
{
    public PacientQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
