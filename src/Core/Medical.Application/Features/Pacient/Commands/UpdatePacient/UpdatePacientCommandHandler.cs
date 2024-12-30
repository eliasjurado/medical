using AutoMapper;
using MediatR;
using Medical.Application.UnitOfWork;
using Medical.Domain.Dto.Pacient;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Resource;

namespace Medical.Application.Features.Pacient.Commands.UpdatePacient;
public record UpdatePacientCommandRequest(PacientDto pacient) : IRequest<IResponse>;
public class UpdatePacientCommandHandler : IRequestHandler<UpdatePacientCommandRequest, IResponse>
{
    private readonly ICommandUnitOfWork<int> _command;
    private readonly IMapper _mapper;
    private readonly IQueryUnitOfWork _query;

    public UpdatePacientCommandHandler(ICommandUnitOfWork<int> command, IMapper mapper, IQueryUnitOfWork query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IResponse> Handle(UpdatePacientCommandRequest request, CancellationToken cancellationToken)
    {
        var pacient = await _query.PacientQuery.GetByIdAsync(i => i.Id == request.pacient.Id);
        if (pacient == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Pacient"), false);
        }

        pacient = _mapper.Map<Domain.Entities.Pacient>(request.pacient);

        if (pacient == null)
        {
            return new DataResponse<string?>(null, HttpStatusCodes.NOT_FOUND, string.Format(Messages.NotFound, "Pacient"), false);
        }

        _command.PacientCommand.Update(pacient);
        await _command.SaveAsync();

        return new DataResponse<string?>(null);
    }
}

