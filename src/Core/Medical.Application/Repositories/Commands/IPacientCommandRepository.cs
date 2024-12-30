using Medical.Application.Repositories.Commands.Base;
using Medical.Domain.Entities;

namespace Medical.Application.Repositories.Commands;

public interface IPacientCommandRepository : ICommandRepository<Pacient, int>
{
}
