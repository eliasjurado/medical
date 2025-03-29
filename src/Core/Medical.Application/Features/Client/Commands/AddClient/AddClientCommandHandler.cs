using Medical.Domain.Dto.Person;

namespace Medical.Application.Features.Client.Commands.AddClient;

public record AddClientCommandRequest(ClientDto item) : IRequest;
public class AddClientCommandHandler : IRequestHandler<AddClientCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddClientCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddClientCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Client>(request.item);
        await _command.ClientCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}

