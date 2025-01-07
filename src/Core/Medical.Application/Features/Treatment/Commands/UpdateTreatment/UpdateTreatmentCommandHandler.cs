using Medical.Domain.Dto.Treatment;

namespace Medical.Application.Features.Treatment.Commands.UpdateTreatment;

public record UpdateTreatmentCommandRequest(TreatmentDto treatment) : IRequest<IResponse>;

public class UpdateTreatmentCommandHandler : IRequestHandler<UpdateTreatmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdateTreatmentCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdateTreatmentCommandRequest request, CancellationToken cancellationToken)
    {
        var treatment = await _query.TreatmentQuery.GetByIdAsync(o => o.Id == request.treatment.Id);
        if (treatment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Treatment"), false);
        }

        treatment = _mapper.Map<Domain.Entities.Treatment>(request.treatment);

        if (treatment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Treatment"), false);
        }

        _command.TreatmentCommand.Update(treatment);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
