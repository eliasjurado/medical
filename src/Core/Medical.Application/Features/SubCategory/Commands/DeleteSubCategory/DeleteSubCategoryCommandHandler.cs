namespace Medical.Application.Features.SubCategory.Commands.DeleteSubCategory;

public record DeleteSubCategoryCommandRequest(int id) : IRequest<IResponse>;

public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteSubCategoryCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.SubCategoryQuery.GetByIdAsync(o => o.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, String.Format(Messages.NotFound, "SubCategory"), false);
        }

        item.IsDeleted = true;
        _command.SubCategoryCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
