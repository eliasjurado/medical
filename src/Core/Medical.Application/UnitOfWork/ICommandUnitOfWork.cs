namespace Medical.Application.UnitOfWork;

public interface ICommandUnitOfWork<Tkey>
{
    IAppointmentCommandRepository AppointmentCommand { get; }
    ICategoryCommandRepository CategoryCommand { get; }
    IPacientCommandRepository PacientCommand { get; }
    ITreatmentCommandRepository TreatmentCommand { get; }
    ISpecialistCommandRepository SpecialistCommand { get; }
    Task<int> SaveAsync();
}
