using Medical.Application.Repositories.Commands;

namespace Medical.Application.UnitOfWork;

public interface ICommandUnitOfWork<Tkey>
{
    ICategoryCommandRepository CategoryCommand { get; }
    IPacientCommandRepository PacientCommand { get; }
    ITreatmentCommandRepository TreatmentCommand { get; }
    ISpecialistCommandRepository SpecialistCommand { get; }
    Task<int> SaveAsync();
}
