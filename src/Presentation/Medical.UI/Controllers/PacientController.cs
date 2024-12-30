using MediatR;
using Medical.Application.Features.Pacient.Commands.AddPacient;
using Medical.Application.Features.Pacient.Commands.DeletePacient;
using Medical.Application.Features.Pacient.Commands.UpdatePacient;
using Medical.Application.Features.Pacient.Queries.GetPacients;
using Medical.Domain.Dto.Pacient;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PacientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetPacients()
    {
        var response = await _mediator.Send(new GetAllPacientQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminPacients()
    {
        var response = await _mediator.Send(new GetAllPacientQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeletePacient(int id)
    {
        var result = await _mediator.Send(new DeletePacientCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<PacientDto>>(new List<PacientDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllPacientQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddPacient(PacientDto category)
    {
        await _mediator.Send(new AddPacientCommandRequest(category));

        var response = await _mediator.Send(new GetAllPacientQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdatePacient(PacientDto category)
    {
        var result = await _mediator.Send(new UpdatePacientCommandRequest(category));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<PacientDto>>(new List<PacientDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllPacientQueryRequest(true));
        return Ok(response);
    }
}
