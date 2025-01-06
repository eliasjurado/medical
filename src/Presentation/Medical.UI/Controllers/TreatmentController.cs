using MediatR;
using Medical.Application.Features.Treatment.Commands.AddTreatment;
using Medical.Application.Features.Treatment.Commands.DeleteTreatment;
using Medical.Application.Features.Treatment.Commands.UpdateTreatment;
using Medical.Application.Features.Treatment.Queries.GetTreatments;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Treatment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public TreatmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetTreatments()
    {
        var response = await _mediator.Send(new GetAllTreatmentQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminTreatments()
    {
        var response = await _mediator.Send(new GetAllTreatmentQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteTreatment(int id)
    {
        var result = await _mediator.Send(new DeleteTreatmentCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<TreatmentDto>>(new List<TreatmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllTreatmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddTreatment(TreatmentDto treatment)
    {
        await _mediator.Send(new AddTreatmentCommandRequest(treatment));

        var response = await _mediator.Send(new GetAllTreatmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateTreatment(TreatmentDto treatment)
    {
        var result = await _mediator.Send(new UpdateTreatmentCommandRequest(treatment));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<TreatmentDto>>(new List<TreatmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllTreatmentQueryRequest(true));
        return Ok(response);
    }
}
