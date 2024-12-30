using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Pacient;

namespace Medical.Application.Features.Pacient.Commands.AddPacient;

public record AddPacientCommandRequest(PacientDto category) : IRequest;
public class AddPacientCommandHandler : IRequestHandler<AddPacientCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddPacientCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddPacientCommandRequest request, CancellationToken cancellationToken)
    {
        var pacient = _mapper.Map<Domain.Entities.Pacient>(request.category);
        await _command.PacientCommand.AddAsync(pacient);
        await _command.SaveAsync();
    }
}

