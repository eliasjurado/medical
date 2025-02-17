using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalProduct.Commands.AddFiscalProduct;

public record AddFiscalProductCommandRequest(FiscalProductDto item) : IRequest;

public class AddFiscalProductCommandHandler : IRequestHandler<AddFiscalProductCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalProductCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalProductCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalProduct>(request.item);
        await _command.FiscalProductCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
