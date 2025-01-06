namespace Medical.Persistence.Repositories.Queries;

public class TreatmentQueryRepository : QueryRepository<Treatment, int>, ITreatmentQueryRepository
{
    public TreatmentQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
