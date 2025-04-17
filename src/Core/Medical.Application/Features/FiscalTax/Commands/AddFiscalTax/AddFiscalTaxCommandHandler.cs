using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalTax.Commands.AddFiscalTax;

public record AddFiscalTaxCommandRequest(FiscalTaxDto item) : IRequest;

public class AddFiscalTaxCommandHandler : IRequestHandler<AddFiscalTaxCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalTaxCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalTaxCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalTax>(request.item);
        await _command.FiscalTaxCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
