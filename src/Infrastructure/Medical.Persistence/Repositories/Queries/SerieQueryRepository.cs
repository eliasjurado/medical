namespace Medical.Persistence.Repositories.Queries;

public class SerieQueryRepository : QueryRepository<Serie, int>, ISerieQueryRepository
{
    public SerieQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
