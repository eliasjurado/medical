using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalFamily.Commands.UpdateFiscalFamily;

public record UpdateFiscalFamilyCommandRequest(FiscalFamilyDto item) : IRequest<IResponse>;

public class UpdateFiscalFamilyCommandHandler : IRequestHandler<UpdateFiscalFamilyCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalFamilyCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalFamilyCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalFamilyQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalFamily)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalFamily>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalFamily)), false);
        }

        _command.FiscalFamilyCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
