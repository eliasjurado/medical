using Medical.Domain.Dto.User;

namespace Medical.Application.Features.AppUser.Commands.AddAppUser;

public record AddAppUserCommandRequest(AppUserDto item) : IRequest;

public class AddAppUserCommandHandler : IRequestHandler<AddAppUserCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddAppUserCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddAppUserCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.AppUser>(request.item);
        await _command.AppUserCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
