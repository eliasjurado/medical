using MediatR;
using Medical.Application.Features.FiscalFamily.Commands.AddFiscalFamily;
using Medical.Application.Features.FiscalFamily.Commands.DeleteFiscalFamily;
using Medical.Application.Features.FiscalFamily.Commands.UpdateFiscalFamily;
using Medical.Application.Features.FiscalFamily.Queries.GetFiscalFamilies;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalFamilyController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalFamilyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalFamilys()
    {
        var response = await _mediator.Send(new GetAllFiscalFamilyQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalFamilys()
    {
        var response = await _mediator.Send(new GetAllFiscalFamilyQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalFamily(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalFamilyCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalFamilyDto>>(new List<FiscalFamilyDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalFamilyQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalFamily(FiscalFamilyDto item)
    {
        await _mediator.Send(new AddFiscalFamilyCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalFamilyQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalFamily(FiscalFamilyDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalFamilyCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalFamilyDto>>(new List<FiscalFamilyDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalFamilyQueryRequest(true));
        return Ok(response);
    }
}
