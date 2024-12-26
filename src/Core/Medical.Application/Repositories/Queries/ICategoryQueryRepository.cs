using Medical.Application.Repositories.Queries.Base;
using Medical.Domain.Entities;

namespace Medical.Application.Repositories.Queries;

public interface ICategoryQueryRepository : IQueryRepository<Category, int>
{
}
