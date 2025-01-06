using Medical.Application.Repositories.Queries.Base;
using Medical.Domain.Entities;

namespace Medical.Application.Repositories.Queries;

public interface ITreatmentQueryRepository : IQueryRepository<Treatment, int>
{
}
