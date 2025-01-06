namespace Medical.Persistence.Repositories.Commands
{
    public class SpecialistCommandRepository : CommandRepository<Specialist, int>, ISpecialistCommandRepository
    {
        public SpecialistCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
