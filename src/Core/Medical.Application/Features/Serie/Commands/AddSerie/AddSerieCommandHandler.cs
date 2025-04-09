using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Serie.Commands.AddSerie;

public record AddSerieCommandRequest(SerieDto item) : IRequest;

public class AddSerieCommandHandler : IRequestHandler<AddSerieCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddSerieCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddSerieCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Serie>(request.item);
        await _command.SerieCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
