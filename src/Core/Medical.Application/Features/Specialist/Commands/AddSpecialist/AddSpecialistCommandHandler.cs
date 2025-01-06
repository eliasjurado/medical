using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Specialist;

namespace Medical.Application.Features.Specialist.Commands.AddSpecialist;

public record AddSpecialistCommandRequest(SpecialistDto specialist) : IRequest;

public class AddSpecialistCommandHandler : IRequestHandler<AddSpecialistCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddSpecialistCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddSpecialistCommandRequest request, CancellationToken cancellationToken)
    {
        var specialist = _mapper.Map<Domain.Entities.Specialist>(request.specialist);
        await _command.SpecialistCommand.AddAsync(specialist);
        await _command.SaveAsync();
    }
}
