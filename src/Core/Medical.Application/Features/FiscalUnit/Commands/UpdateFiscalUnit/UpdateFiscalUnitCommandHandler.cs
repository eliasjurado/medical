using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalUnit.Commands.UpdateFiscalUnit;

public record UpdateFiscalUnitCommandRequest(FiscalUnitDto item) : IRequest<IResponse>;

public class UpdateFiscalUnitCommandHandler : IRequestHandler<UpdateFiscalUnitCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalUnitCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalUnitCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalUnitQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalUnit)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalUnit>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalUnit)), false);
        }

        _command.FiscalUnitCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
