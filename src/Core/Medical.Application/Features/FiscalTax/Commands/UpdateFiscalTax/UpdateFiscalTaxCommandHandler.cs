using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalTax.Commands.UpdateFiscalTax;

public record UpdateFiscalTaxCommandRequest(FiscalTaxDto item) : IRequest<IResponse>;

public class UpdateFiscalTaxCommandHandler : IRequestHandler<UpdateFiscalTaxCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalTaxCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalTaxCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalTaxQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalTax)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalTax>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalTax)), false);
        }

        _command.FiscalTaxCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
