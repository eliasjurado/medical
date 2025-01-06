using MediatR;
using Medical.Application.Features.Specialist.Commands.AddSpecialist;
using Medical.Application.Features.Specialist.Commands.DeleteSpecialist;
using Medical.Application.Features.Specialist.Commands.UpdateSpecialist;
using Medical.Application.Features.Specialist.Queries.GetSpecialists;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Specialist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialistController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecialistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetSpecialists()
    {
        var response = await _mediator.Send(new GetAllSpecialistQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminSpecialists()
    {
        var response = await _mediator.Send(new GetAllSpecialistQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteSpecialist(int id)
    {
        var result = await _mediator.Send(new DeleteSpecialistCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SpecialistDto>>(new List<SpecialistDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllSpecialistQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddSpecialist(SpecialistDto specialist)
    {
        await _mediator.Send(new AddSpecialistCommandRequest(specialist));

        var response = await _mediator.Send(new GetAllSpecialistQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateSpecialist(SpecialistDto specialist)
    {
        var result = await _mediator.Send(new UpdateSpecialistCommandRequest(specialist));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SpecialistDto>>(new List<SpecialistDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault());
        }

        var response = await _mediator.Send(new GetAllSpecialistQueryRequest(true));
        return Ok(response);
    }
}
