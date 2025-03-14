using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Warehouse.Commands.UpdateWarehouse;

public record UpdateWarehouseCommandRequest(WarehouseDto item) : IRequest<IResponse>;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateWarehouseCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateWarehouseCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.WarehouseQuery.GetByIdAsync(o => o.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Warehouse"), false);
        }

        item = _mapper.Map<Domain.Entities.Warehouse>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Warehouse"), false);
        }

        _command.WarehouseCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
