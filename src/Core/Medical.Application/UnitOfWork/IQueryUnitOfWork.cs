namespace Medical.Application.UnitOfWork;

public interface IQueryUnitOfWork
{
    IAppointmentQueryRepository AppointmentQuery { get; }
    ICategoryQueryRepository CategoryQuery { get; }
    IPacientQueryRepository PacientQuery { get; }
    ITreatmentQueryRepository TreatmentQuery { get; }
    ISpecialistQueryRepository SpecialistQuery { get; }
    IBrandQueryRepository BrandQuery { get; }
    IFiscalUnitQueryRepository FiscalUnitQuery { get; }
    IFiscalSegmentQueryRepository FiscalSegmentQuery { get; }
    IFiscalFamilyQueryRepository FiscalFamilyQuery { get; }
    IFiscalClassQueryRepository FiscalClassQuery { get; }
    IFiscalProductQueryRepository FiscalProductQuery { get; }
    IArticleQueryRepository ArticleQuery { get; }

}
