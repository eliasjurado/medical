using Medical.Application.Repositories.Commands.Base;
using Medical.Domain.Entities;

namespace Medical.Application.Repositories.Commands;

public interface ITreatmentCommandRepository : ICommandRepository<Treatment, int>
{
}
