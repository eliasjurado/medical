using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalClass.Commands.AddFiscalClass;

public record AddFiscalClassCommandRequest(FiscalClassDto item) : IRequest;

public class AddFiscalClassCommandHandler : IRequestHandler<AddFiscalClassCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalClassCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalClassCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalClass>(request.item);
        await _command.FiscalClassCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
