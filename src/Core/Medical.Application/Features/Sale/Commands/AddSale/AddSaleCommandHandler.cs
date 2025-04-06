using Medical.Application.Contracts.Identity;
using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Sale.Commands.AddSale;

public record AddSaleCommandRequest(SaleDto item) : IRequest<IResponse>;

public class AddSaleCommandHandler : IRequestHandler<AddSaleCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public AddSaleCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, ICurrentUser currentUser)
    {
        _command = command;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<IResponse> Handle(AddSaleCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Sale>(request.item);
        item.UserId = _currentUser.UserId;
        await _command.SaleCommand.AddAsync(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
