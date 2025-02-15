namespace Medical.Application.Features.Brand.Commands.DeleteBrand;

public record DeleteBrandCommandRequest(int id) : IRequest<IResponse>;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteBrandCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.BrandQuery.GetByIdAsync(i => i.Id == request.id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Brand)), false);
        }

        item.IsDeleted = true;
        _command.BrandCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
