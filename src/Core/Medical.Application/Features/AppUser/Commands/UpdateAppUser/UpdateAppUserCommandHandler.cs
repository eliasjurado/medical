using Medical.Domain.Dto.User;

namespace Medical.Application.Features.AppUser.Commands.UpdateAppUser;

public record UpdateAppUserCommandRequest(AppUserDto item) : IRequest<IResponse>;

public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateAppUserCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.AppUserQuery.GetByIdAsync(o => o.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "AppUser"), false);
        }

        item = _mapper.Map<Domain.Entities.AppUser>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "AppUser"), false);
        }

        _command.AppUserCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
