using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Resource;

namespace Medical.Application.Features.Treatment.Commands.DeleteTreatment;

public record DeleteTreatmentCommandRequest(int id) : IRequest<IResponse>;

public class DeleteTreatmentCommandHandler : IRequestHandler<DeleteTreatmentCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IQueryUnitOfWork _query;

    public DeleteTreatmentCommandHandler(ICommandUnitOfWork<int> command, IQueryUnitOfWork query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResponse> Handle(DeleteTreatmentCommandRequest request, CancellationToken cancellationToken)
    {
        var treatment = await _query.TreatmentQuery.GetByIdAsync(o => o.Id == request.id);
        if (treatment == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Treatment"), false);
        }

        treatment.IsDeleted = true;
        _command.TreatmentCommand.Update(treatment);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}
