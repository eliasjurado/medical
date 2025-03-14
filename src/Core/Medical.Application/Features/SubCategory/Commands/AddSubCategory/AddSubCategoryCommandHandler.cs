using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.SubCategory.Commands.AddSubCategory;

public record AddSubCategoryCommandRequest(SubCategoryDto item) : IRequest;

public class AddSubCategoryCommandHandler : IRequestHandler<AddSubCategoryCommandRequest>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;

    public AddSubCategoryCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task Handle(AddSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.SubCategory>(request.item);
        await _command.SubCategoryCommand.AddAsync(item);
        await _command.SaveAsync();
    }
}
