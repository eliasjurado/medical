using Medical.Domain.Dto.Person;

namespace Medical.Application.Features.Client.Commands.UpdateClient;
public record UpdateClientCommandRequest(ClientDto Client) : IRequest<IResponse>;
public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateClientCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateClientCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ClientQuery.GetByIdAsync(i => i.Id == request.Client.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Client"), false);
        }

        item = _mapper.Map<Domain.Entities.Client>(request.Client);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Client"), false);
        }

        _command.ClientCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}

