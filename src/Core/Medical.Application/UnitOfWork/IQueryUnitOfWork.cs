using Medical.Application.Repositories.Queries;

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
    
}
