using Medical.Domain.Dto.Brand;

namespace Medical.Application.Features.Brand.Commands.UpdateBrand;

public record UpdateBrandCommandRequest(BrandDto item) : IRequest<IResponse>;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateBrandCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _query.BrandQuery.GetByIdAsync(i => i.Id == request.item.Id);
        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Brand)), false);
        }

        item = _mapper.Map<Domain.Entities.Brand>(request.item);

        if (item == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, nameof(Domain.Entities.Brand)), false);
        }

        _command.BrandCommand.Update(item);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
