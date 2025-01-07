using Medical.Domain.Dto.Specialist;

namespace Medical.Application.Features.Specialist.Commands.UpdateSpecialist;

public record UpdateSpecialistCommandRequest(SpecialistDto specialist) : IRequest<IResponse>;

public class UpdateSpecialistCommandHandler : IRequestHandler<UpdateSpecialistCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateSpecialistCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateSpecialistCommandRequest request, CancellationToken cancellationToken)
    {
        var specialist = await _query.SpecialistQuery.GetByIdAsync(o => o.Id == request.specialist.Id);
        if (specialist == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Specialist"), false);
        }

        specialist = _mapper.Map<Domain.Entities.Specialist>(request.specialist);

        if (specialist == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Specialist"), false);
        }

        _command.SpecialistCommand.Update(specialist);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
