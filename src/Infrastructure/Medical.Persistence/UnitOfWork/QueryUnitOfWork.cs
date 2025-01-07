namespace Medical.Persistence.UnitOfWork;

public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly PersistenceDataContext _context;

    public QueryUnitOfWork(PersistenceDataContext context)
    {
        _context = context;
    }

    public CategoryQueryRepository _categoryQuery;
    public PacientQueryRepository _pacientQuery;
    public TreatmentQueryRepository _treatmentQuery;
    public SpecialistQueryRepository _specialistQuery;
    public AppointmentQueryRepository _appointmentQuery;

    public ICategoryQueryRepository CategoryQuery => _categoryQuery ?? (_categoryQuery = new CategoryQueryRepository(_context));
    public IPacientQueryRepository PacientQuery => _pacientQuery ?? (_pacientQuery = new PacientQueryRepository(_context));
    public ITreatmentQueryRepository TreatmentQuery => _treatmentQuery ?? (_treatmentQuery = new TreatmentQueryRepository(_context));
    public ISpecialistQueryRepository SpecialistQuery => _specialistQuery ?? (_specialistQuery = new SpecialistQueryRepository(_context));
    public IAppointmentQueryRepository AppointmentQuery => _appointmentQuery ?? (_appointmentQuery = new AppointmentQueryRepository(_context));
}
