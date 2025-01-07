namespace Medical.Persistence.Repositories.Commands
{
    public class AppointmentCommandRepository : CommandRepository<Appointment, int>, IAppointmentCommandRepository
    {
        public AppointmentCommandRepository(PersistenceDataContext context) : base(context)
        {
        }
    }
}
