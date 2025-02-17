using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalFamily.Commands.AddFiscalFamily;

public record AddFiscalFamilyCommandRequest(FiscalFamilyDto item) : IRequest;

public class AddFiscalFamilyCommandHandler : IRequestHandler<AddFiscalFamilyCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalFamilyCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalFamilyCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalFamily>(request.item);
        await _command.FiscalFamilyCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
