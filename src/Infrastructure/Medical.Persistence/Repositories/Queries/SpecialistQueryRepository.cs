namespace Medical.Persistence.Repositories.Queries;

public class SpecialistQueryRepository : QueryRepository<Specialist, int>, ISpecialistQueryRepository
{
    public SpecialistQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
