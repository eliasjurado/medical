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
    private SubCategoryCommandRepository? _subCategoryCommand;
    private PacientCommandRepository? _pacientCommand;
    private TreatmentCommandRepository? _treatmentCommand;
    private WarehouseCommandRepository? _warehouseCommand;
    private SpecialistCommandRepository? _specialistCommand;
    private AppointmentCommandRepository? _appointmentCommand;
    private BrandCommandRepository? _brandCommand;
    private ArticleCommandRepository? _articleCommand;
    private ArticleStockCommandRepository? _articleStockCommand;
    private FiscalUnitCommandRepository? _fiscalUnitCommand;
    private FiscalSegmentCommandRepository? _fiscalSegmentCommand;
    private FiscalFamilyCommandRepository? _fiscalFamilyCommand;
    private FiscalClassCommandRepository? _fiscalClassCommand;
    private FiscalProductCommandRepository? _fiscalProductCommand;

    public ICategoryCommandRepository CategoryCommand => _categoryCommand ?? (_categoryCommand = new CategoryCommandRepository(_context));
    public ISubCategoryCommandRepository SubCategoryCommand => _subCategoryCommand ?? (_subCategoryCommand = new SubCategoryCommandRepository(_context));
    public IPacientCommandRepository PacientCommand => _pacientCommand ?? (_pacientCommand = new PacientCommandRepository(_context));
    public ITreatmentCommandRepository TreatmentCommand => _treatmentCommand ?? (_treatmentCommand = new TreatmentCommandRepository(_context));
    public IWarehouseCommandRepository WarehouseCommand => _warehouseCommand ?? (_warehouseCommand = new WarehouseCommandRepository(_context));
    public ISpecialistCommandRepository SpecialistCommand => _specialistCommand ?? (_specialistCommand = new SpecialistCommandRepository(_context));
    public IAppointmentCommandRepository AppointmentCommand => _appointmentCommand ?? (_appointmentCommand = new AppointmentCommandRepository(_context));
    public IBrandCommandRepository BrandCommand => _brandCommand ?? (_brandCommand = new BrandCommandRepository(_context));
    public IArticleCommandRepository ArticleCommand => _articleCommand ?? (_articleCommand = new ArticleCommandRepository(_context));
    public IArticleStockCommandRepository ArticleStockCommand => _articleStockCommand ?? (_articleStockCommand = new ArticleStockCommandRepository(_context));
    public IFiscalUnitCommandRepository FiscalUnitCommand => _fiscalUnitCommand ?? (_fiscalUnitCommand = new FiscalUnitCommandRepository(_context));
    public IFiscalSegmentCommandRepository FiscalSegmentCommand => _fiscalSegmentCommand ?? (_fiscalSegmentCommand = new FiscalSegmentCommandRepository(_context));
    public IFiscalFamilyCommandRepository FiscalFamilyCommand => _fiscalFamilyCommand ?? (_fiscalFamilyCommand = new FiscalFamilyCommandRepository(_context));
    public IFiscalClassCommandRepository FiscalClassCommand => _fiscalClassCommand ?? (_fiscalClassCommand = new FiscalClassCommandRepository(_context));
    public IFiscalProductCommandRepository FiscalProductCommand => _fiscalProductCommand ?? (_fiscalProductCommand = new FiscalProductCommandRepository(_context));

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
