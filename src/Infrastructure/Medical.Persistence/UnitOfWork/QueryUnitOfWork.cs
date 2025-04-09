namespace Medical.Persistence.UnitOfWork;

public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly PersistenceDataContext _context;

    public QueryUnitOfWork(PersistenceDataContext context)
    {
        _context = context;
    }

    private AppUserQueryRepository? _appUserQuery;
    private SerieQueryRepository? _serieQuery;
    private CategoryQueryRepository? _categoryQuery;
    private SubCategoryQueryRepository? _subCategoryQuery;
    private ClientQueryRepository? _clientQuery;
    private PacientQueryRepository? _pacientQuery;
    private TreatmentQueryRepository? _treatmentQuery;
    private WarehouseQueryRepository? _warehouseQuery;
    private SpecialistQueryRepository? _specialistQuery;
    private AppointmentQueryRepository? _appointmentQuery;
    private BrandQueryRepository? _brandQuery;
    private SaleQueryRepository? _saleQuery;
    private SaleArticleQueryRepository? _saleArticleQuery;
    private ArticleQueryRepository? _articleQuery;
    private ArticleStockQueryRepository? _articleStockQuery;
    private FiscalUnitQueryRepository? _fiscalUnitQuery;
    private FiscalSegmentQueryRepository? _fiscalSegmentQuery;
    private FiscalFamilyQueryRepository? _fiscalFamilyQuery;
    private FiscalClassQueryRepository? _fiscalClassQuery;
    private FiscalProductQueryRepository? _fiscalProductQuery;

    public ISerieQueryRepository SerieQuery => _serieQuery ?? (_serieQuery = new SerieQueryRepository(_context));
    public IAppUserQueryRepository AppUserQuery => _appUserQuery ?? (_appUserQuery = new AppUserQueryRepository(_context));
    public ICategoryQueryRepository CategoryQuery => _categoryQuery ?? (_categoryQuery = new CategoryQueryRepository(_context));
    public ISubCategoryQueryRepository SubCategoryQuery => _subCategoryQuery ?? (_subCategoryQuery = new SubCategoryQueryRepository(_context));
    public IClientQueryRepository ClientQuery => _clientQuery ?? (_clientQuery = new ClientQueryRepository(_context));
    public IPacientQueryRepository PacientQuery => _pacientQuery ?? (_pacientQuery = new PacientQueryRepository(_context));
    public ITreatmentQueryRepository TreatmentQuery => _treatmentQuery ?? (_treatmentQuery = new TreatmentQueryRepository(_context));
    public IWarehouseQueryRepository WarehouseQuery => _warehouseQuery ?? (_warehouseQuery = new WarehouseQueryRepository(_context));
    public ISpecialistQueryRepository SpecialistQuery => _specialistQuery ?? (_specialistQuery = new SpecialistQueryRepository(_context));
    public IAppointmentQueryRepository AppointmentQuery => _appointmentQuery ?? (_appointmentQuery = new AppointmentQueryRepository(_context));
    public IBrandQueryRepository BrandQuery => _brandQuery ?? (_brandQuery = new BrandQueryRepository(_context));
    public ISaleQueryRepository SaleQuery => _saleQuery ?? (_saleQuery = new SaleQueryRepository(_context));
    public ISaleArticleQueryRepository SaleArticleQuery => _saleArticleQuery ?? (_saleArticleQuery = new SaleArticleQueryRepository(_context));
    public IArticleQueryRepository ArticleQuery => _articleQuery ?? (_articleQuery = new ArticleQueryRepository(_context));
    public IArticleStockQueryRepository ArticleStockQuery => _articleStockQuery ?? (_articleStockQuery = new ArticleStockQueryRepository(_context));
    public IFiscalUnitQueryRepository FiscalUnitQuery => _fiscalUnitQuery ?? (_fiscalUnitQuery = new FiscalUnitQueryRepository(_context));
    public IFiscalSegmentQueryRepository FiscalSegmentQuery => _fiscalSegmentQuery ?? (_fiscalSegmentQuery = new FiscalSegmentQueryRepository(_context));
    public IFiscalFamilyQueryRepository FiscalFamilyQuery => _fiscalFamilyQuery ?? (_fiscalFamilyQuery = new FiscalFamilyQueryRepository(_context));
    public IFiscalClassQueryRepository FiscalClassQuery => _fiscalClassQuery ?? (_fiscalClassQuery = new FiscalClassQueryRepository(_context));
    public IFiscalProductQueryRepository FiscalProductQuery => _fiscalProductQuery ?? (_fiscalProductQuery = new FiscalProductQueryRepository(_context));
}
