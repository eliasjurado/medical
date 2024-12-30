using Medical.Application.Repositories.Commands;

namespace Medical.Application.UnitOfWork;

public interface ICommandUnitOfWork<Tkey>
{
    ICategoryCommandRepository CategoryCommand { get; }
    IPacientCommandRepository PacientCommand { get; }
    Task<int> SaveAsync();
}
