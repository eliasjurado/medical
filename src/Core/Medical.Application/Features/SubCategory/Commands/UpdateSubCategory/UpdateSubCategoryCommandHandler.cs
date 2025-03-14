using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.SubCategory.Commands.UpdateSubCategory;

public record UpdateSubCategoryCommandRequest(SubCategoryDto item) : IRequest<IResponse>;

public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateSubCategoryCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.SubCategoryQuery.GetByIdAsync(o => o.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "SubCategory"), false);
        }

        item = _mapper.Map<Domain.Entities.SubCategory>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "SubCategory"), false);
        }

        _command.SubCategoryCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
