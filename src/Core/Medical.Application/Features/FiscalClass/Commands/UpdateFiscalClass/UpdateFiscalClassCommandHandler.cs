using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalClass.Commands.UpdateFiscalClass;

public record UpdateFiscalClassCommandRequest(FiscalClassDto item) : IRequest<IResponse>;

public class UpdateFiscalClassCommandHandler : IRequestHandler<UpdateFiscalClassCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalClassCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalClassCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalClassQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalClass)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalClass>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalClass)), false);
        }

        _command.FiscalClassCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
