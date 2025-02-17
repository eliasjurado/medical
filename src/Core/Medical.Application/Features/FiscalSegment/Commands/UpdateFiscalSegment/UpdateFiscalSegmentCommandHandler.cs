using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.Features.FiscalSegment.Commands.UpdateFiscalSegment;

public record UpdateFiscalSegmentCommandRequest(FiscalSegmentDto item) : IRequest<IResponse>;

public class UpdateFiscalSegmentCommandHandler : IRequestHandler<UpdateFiscalSegmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateFiscalSegmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateFiscalSegmentCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.FiscalSegmentQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalSegment)), false);
        }

        item = _mapper.Map<Domain.Entities.FiscalSegment>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.FiscalSegment)), false);
        }

        _command.FiscalSegmentCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
