using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalProduct.Commands.UpdateFiscalProduct;

public record UpdateFiscalProductCommandRequest(FiscalProductDto item) : IRequest<IResponse>;

public class UpdateFiscalProductCommandHandler : IRequestHandler<UpdateFiscalProductCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalProductCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalProductCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalProductQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalProduct)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalProduct>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalProduct)), false);
        }

        _command.FiscalProductCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
