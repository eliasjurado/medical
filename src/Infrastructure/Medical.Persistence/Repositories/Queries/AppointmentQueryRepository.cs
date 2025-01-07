namespace Medical.Persistence.Repositories.Queries;

public class AppointmentQueryRepository : QueryRepository<Appointment, int>, IAppointmentQueryRepository
{
    public AppointmentQueryRepository(PersistenceDataContext context) : base(context)
    {
    }
}
