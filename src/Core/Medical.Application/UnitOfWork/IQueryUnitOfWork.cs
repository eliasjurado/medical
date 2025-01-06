using Medical.Application.Repositories.Queries;

namespace Medical.Application.UnitOfWork;

public interface IQueryUnitOfWork
{
    ICategoryQueryRepository CategoryQuery { get; }
    IPacientQueryRepository PacientQuery { get; }
    ITreatmentQueryRepository TreatmentQuery { get; }
    ISpecialistQueryRepository SpecialistQuery { get; }
}
