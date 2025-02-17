namespace Medical.Persistence.UnitOfWork;

public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly PersistenceDataContext _context;

    public QueryUnitOfWork(PersistenceDataContext context)
    {
        _context = context;
    }

    private CategoryQueryRepository? _categoryQuery;
    private PacientQueryRepository? _pacientQuery;
    private TreatmentQueryRepository? _treatmentQuery;
    private SpecialistQueryRepository? _specialistQuery;
    private AppointmentQueryRepository? _appointmentQuery;
    private BrandQueryRepository? _brandQuery;
    private ArticleQueryRepository? _articleQuery;
    private FiscalUnitQueryRepository? _fiscalUnitQuery;
    private FiscalSegmentQueryRepository? _fiscalSegmentQuery;
    private FiscalFamilyQueryRepository? _fiscalFamilyQuery;
    private FiscalClassQueryRepository? _fiscalClassQuery;
    private FiscalProductQueryRepository? _fiscalProductQuery;


    public ICategoryQueryRepository CategoryQuery => _categoryQuery ?? (_categoryQuery = new CategoryQueryRepository(_context));
    public IPacientQueryRepository PacientQuery => _pacientQuery ?? (_pacientQuery = new PacientQueryRepository(_context));
    public ITreatmentQueryRepository TreatmentQuery => _treatmentQuery ?? (_treatmentQuery = new TreatmentQueryRepository(_context));
    public ISpecialistQueryRepository SpecialistQuery => _specialistQuery ?? (_specialistQuery = new SpecialistQueryRepository(_context));
    public IAppointmentQueryRepository AppointmentQuery => _appointmentQuery ?? (_appointmentQuery = new AppointmentQueryRepository(_context));
    public IBrandQueryRepository BrandQuery => _brandQuery ?? (_brandQuery = new BrandQueryRepository(_context));
    public IArticleQueryRepository ArticleQuery => _articleQuery ?? (_articleQuery = new ArticleQueryRepository(_context));
    public IFiscalUnitQueryRepository FiscalUnitQuery => _fiscalUnitQuery ?? (_fiscalUnitQuery = new FiscalUnitQueryRepository(_context));
    public IFiscalSegmentQueryRepository FiscalSegmentQuery => _fiscalSegmentQuery ?? (_fiscalSegmentQuery = new FiscalSegmentQueryRepository(_context));
    public IFiscalFamilyQueryRepository FiscalFamilyQuery => _fiscalFamilyQuery ?? (_fiscalFamilyQuery = new FiscalFamilyQueryRepository(_context));
    public IFiscalClassQueryRepository FiscalClassQuery => _fiscalClassQuery ?? (_fiscalClassQuery = new FiscalClassQueryRepository(_context));
    public IFiscalProductQueryRepository FiscalProductQuery => _fiscalProductQuery ?? (_fiscalProductQuery = new FiscalProductQueryRepository(_context));
}
