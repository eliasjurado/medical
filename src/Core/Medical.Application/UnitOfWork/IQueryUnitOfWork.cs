namespace Medical.Application.UnitOfWork;

public interface IQueryUnitOfWork
{
    IAppointmentQueryRepository AppointmentQuery { get; }
    ISerieQueryRepository SerieQuery { get; }
    IAppUserQueryRepository AppUserQuery { get; }
    ICategoryQueryRepository CategoryQuery { get; }
    ISubCategoryQueryRepository SubCategoryQuery { get; }
    IPacientQueryRepository PacientQuery { get; }
    IClientQueryRepository ClientQuery { get; }
    ITreatmentQueryRepository TreatmentQuery { get; }
    IWarehouseQueryRepository WarehouseQuery { get; }
    ISpecialistQueryRepository SpecialistQuery { get; }
    IBrandQueryRepository BrandQuery { get; }
    ISaleQueryRepository SaleQuery { get; }
    ISaleArticleQueryRepository SaleArticleQuery { get; }
    IFiscalUnitQueryRepository FiscalUnitQuery { get; }
    IFiscalSegmentQueryRepository FiscalSegmentQuery { get; }
    IFiscalFamilyQueryRepository FiscalFamilyQuery { get; }
    IFiscalClassQueryRepository FiscalClassQuery { get; }
    IFiscalProductQueryRepository FiscalProductQuery { get; }
    IArticleQueryRepository ArticleQuery { get; }
    IArticleStockQueryRepository ArticleStockQuery { get; }
    IFiscalTaxQueryRepository FiscalTaxQuery { get; }
}
