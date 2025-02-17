using MediatR;
using Medical.Application.Features.FiscalSegment.Commands.AddFiscalSegment;
using Medical.Application.Features.FiscalSegment.Commands.DeleteFiscalSegment;
using Medical.Application.Features.FiscalSegment.Commands.UpdateFiscalSegment;
using Medical.Application.Features.FiscalSegment.Queries.GetFiscalSegments;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalSegmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalSegmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalSegments()
    {
        var response = await _mediator.Send(new GetAllFiscalSegmentQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalSegments()
    {
        var response = await _mediator.Send(new GetAllFiscalSegmentQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalSegment(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalSegmentCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalSegmentDto>>(new List<FiscalSegmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalSegmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalSegment(FiscalSegmentDto item)
    {
        await _mediator.Send(new AddFiscalSegmentCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalSegmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalSegment(FiscalSegmentDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalSegmentCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalSegmentDto>>(new List<FiscalSegmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalSegmentQueryRequest(true));
        return Ok(response);
    }
}
