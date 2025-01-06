namespace Medical.Persistence.Repositories.Commands
{
    public class TreatmentCommandRepository : CommandRepository<Treatment, int>, ITreatmentCommandRepository
    {
        public TreatmentCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
