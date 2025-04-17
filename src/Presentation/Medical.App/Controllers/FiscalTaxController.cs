using MediatR;
using Medical.Application.Features.FiscalTax.Commands.AddFiscalTax;
using Medical.Application.Features.FiscalTax.Commands.DeleteFiscalTax;
using Medical.Application.Features.FiscalTax.Commands.UpdateFiscalTax;
using Medical.Application.Features.FiscalTax.Queries.GetFiscalTaxes;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalTaxController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalTaxController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalTaxes()
    {
        var response = await _mediator.Send(new GetAllFiscalTaxQueryRequest());
        return Ok(response);
    }

    [HttpGet("year")]
    public async Task<ActionResult<IResponse>> GetFiscalTaxByYear(int year)
    {
        var response = await _mediator.Send(new GetFiscalTaxByYearQueryRequest(year));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalTaxes()
    {
        var response = await _mediator.Send(new GetAllFiscalTaxQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalTax(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalTaxCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalTaxDto>>(new List<FiscalTaxDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalTaxQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalTax(FiscalTaxDto item)
    {
        await _mediator.Send(new AddFiscalTaxCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalTaxQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalTax(FiscalTaxDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalTaxCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalTaxDto>>(new List<FiscalTaxDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalTaxQueryRequest(true));
        return Ok(response);
    }
}
