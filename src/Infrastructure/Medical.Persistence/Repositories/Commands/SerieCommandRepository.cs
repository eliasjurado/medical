namespace Medical.Persistence.Repositories.Commands;

public class SerieCommandRepository : CommandRepository<Serie, int>, ISerieCommandRepository
{
    public SerieCommandRepository(PersistenceDataContext context) : base(context)
    {
    }
}
