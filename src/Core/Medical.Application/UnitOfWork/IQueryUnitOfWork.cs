using Medical.Application.Repositories.Queries;

namespace Medical.Application.UnitOfWork;

public interface IQueryUnitOfWork
{
    ICategoryQueryRepository CategoryQuery { get; }

}
