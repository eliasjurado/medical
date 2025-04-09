using Medical.Domain.Dto.Sales;

namespace Medical.Application.Features.Serie.Commands.UpdateSerie;

public record UpdateSerieCommandRequest(SerieDto item) : IRequest<IResponse>;

public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateSerieCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateSerieCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.SerieQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Serie)), false);
        }

        item = _mapper.Map<Domain.Entities.Serie>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Serie)), false);
        }

        _command.SerieCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
