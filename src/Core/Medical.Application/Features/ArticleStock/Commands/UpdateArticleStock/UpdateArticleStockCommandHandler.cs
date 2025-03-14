using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.ArticleStock.Commands.UpdateArticleStock;

public record UpdateArticleStockCommandRequest(ArticleStockDto item) : IRequest<IResponse>;

public class UpdateArticleStockCommandHandler : IRequestHandler<UpdateArticleStockCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateArticleStockCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateArticleStockCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.ArticleStockQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.ArticleStock)), false);
        }

        item = _mapper.Map<Domain.Entities.ArticleStock>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.ArticleStock)), false);
        }

        _command.ArticleStockCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
