using MediatR;
using Medical.Application.Features.FiscalUnit.Commands.AddFiscalUnit;
using Medical.Application.Features.FiscalUnit.Commands.DeleteFiscalUnit;
using Medical.Application.Features.FiscalUnit.Commands.UpdateFiscalUnit;
using Medical.Application.Features.FiscalUnit.Queries.GetFiscalUnits;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalUnitController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalUnitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalUnits()
    {
        var response = await _mediator.Send(new GetAllFiscalUnitQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetFiscalUnitByName(string name)
    {
        var response = await _mediator.Send(new GetFiscalUnitByNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalUnits()
    {
        var response = await _mediator.Send(new GetAllFiscalUnitQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalUnit(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalUnitCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalUnitDto>>(new List<FiscalUnitDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalUnitQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalUnit(FiscalUnitDto item)
    {
        await _mediator.Send(new AddFiscalUnitCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalUnitQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalUnit(FiscalUnitDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalUnitCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalUnitDto>>(new List<FiscalUnitDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalUnitQueryRequest(true));
        return Ok(response);
    }
}
