using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Treatment;

namespace Medical.Application.Features.Treatment.Commands.AddTreatment;

public record AddTreatmentCommandRequest(TreatmentDto treatment) : IRequest;

public class AddTreatmentCommandHandler : IRequestHandler<AddTreatmentCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddTreatmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddTreatmentCommandRequest request, CancellationToken cancellationToken)
    {
        var treatment = _mapper.Map<Domain.Entities.Treatment>(request.treatment);
        await _command.TreatmentCommand.AddAsync(treatment);
        await _command.SaveAsync();
    }
}
