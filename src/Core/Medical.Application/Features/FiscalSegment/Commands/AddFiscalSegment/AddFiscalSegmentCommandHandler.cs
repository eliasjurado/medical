using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalSegment.Commands.AddFiscalSegment;

public record AddFiscalSegmentCommandRequest(FiscalSegmentDto item) : IRequest;

public class AddFiscalSegmentCommandHandler : IRequestHandler<AddFiscalSegmentCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddFiscalSegmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddFiscalSegmentCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.FiscalSegment>(request.item);
        await _command.FiscalSegmentCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
