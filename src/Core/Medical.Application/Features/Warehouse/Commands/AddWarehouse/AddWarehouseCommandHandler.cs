using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Warehouse.Commands.AddWarehouse;

public record AddWarehouseCommandRequest(WarehouseDto item) : IRequest;

public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddWarehouseCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddWarehouseCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Warehouse>(request.item);
        await _command.WarehouseCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
