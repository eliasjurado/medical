using Medical.Domain.Dto.Brand;

namespace Medical.Application.Features.Brand.Commands.AddBrand;

public record AddBrandCommandRequest(BrandDto item) : IRequest;

public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddBrandCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.Brand>(request.item);
        await _command.BrandCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
