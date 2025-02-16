using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalUnit.Commands.AddFiscalUnit;

public record AddFiscalUnitCommandRequest(FiscalUnitDto item) : IRequest;

public class AddFiscalUnitCommandHandler : IRequestHandler<AddFiscalUnitCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalUnitCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalUnitCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalUnit>(request.item);
        await _command.FiscalUnitCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
