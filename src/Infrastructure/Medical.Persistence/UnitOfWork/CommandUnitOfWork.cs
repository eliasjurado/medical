namespace Medical.Persistence.UnitOfWork;

public class CommandUnitOfWork<Tkey> : ICommandUnitOfWork<Tkey>
{
    private readonly ICurrentUser _currentUser;
    private readonly PersistenceDataContext _context;

    public CommandUnitOfWork(PersistenceDataContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    private CategoryCommandRepository? _categoryCommand;
    private PacientCommandRepository? _pacientCommand;
    private TreatmentCommandRepository? _treatmentCommand;
    private SpecialistCommandRepository? _specialistCommand;
    private AppointmentCommandRepository? _appointmentCommand;
    private BrandCommandRepository? _brandCommand;
    private FiscalUnitCommandRepository? _fiscalUnitCommand;
    

    public ICategoryCommandRepository CategoryCommand => _categoryCommand ?? (_categoryCommand = new CategoryCommandRepository(_context));
    public IPacientCommandRepository PacientCommand => _pacientCommand ?? (_pacientCommand = new PacientCommandRepository(_context));
    public ITreatmentCommandRepository TreatmentCommand => _treatmentCommand ?? (_treatmentCommand = new TreatmentCommandRepository(_context));
    public ISpecialistCommandRepository SpecialistCommand => _specialistCommand ?? (_specialistCommand = new SpecialistCommandRepository(_context));
    public IAppointmentCommandRepository AppointmentCommand => _appointmentCommand ?? (_appointmentCommand = new AppointmentCommandRepository(_context));
    public IBrandCommandRepository BrandCommand => _brandCommand ?? (_brandCommand = new BrandCommandRepository(_context));
    public IFiscalUnitCommandRepository FiscalUnitCommand => _fiscalUnitCommand ?? (_fiscalUnitCommand = new FiscalUnitCommandRepository(_context));

    public async Task<int> SaveAsync()
    {
        AuditEntities(_context);
        return await _context.SaveChangesAsync();
    }

    private void AuditEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity<Tkey>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = _currentUser.UserId;
            }
            if (entry.State == EntityState.Added ||
                entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedBy = _currentUser.UserId;
                entry.Entity.LastModifiedUtc = DateTime.UtcNow;
            }
        }
    }
}
