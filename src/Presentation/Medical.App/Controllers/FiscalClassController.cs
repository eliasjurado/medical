using MediatR;
using Medical.Application.Features.FiscalClass.Commands.AddFiscalClass;
using Medical.Application.Features.FiscalClass.Commands.DeleteFiscalClass;
using Medical.Application.Features.FiscalClass.Commands.UpdateFiscalClass;
using Medical.Application.Features.FiscalClass.Queries.GetFiscalClasses;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalClassController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalClassController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalClasss()
    {
        var response = await _mediator.Send(new GetAllFiscalClassQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalClasss()
    {
        var response = await _mediator.Send(new GetAllFiscalClassQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalClass(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalClassCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalClassDto>>(new List<FiscalClassDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalClassQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalClass(FiscalClassDto item)
    {
        await _mediator.Send(new AddFiscalClassCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalClassQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalClass(FiscalClassDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalClassCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalClassDto>>(new List<FiscalClassDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalClassQueryRequest(true));
        return Ok(response);
    }
}
