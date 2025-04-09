using MediatR;
using Medical.Application.Features.Serie.Commands.AddSerie;
using Medical.Application.Features.Serie.Commands.DeleteSerie;
using Medical.Application.Features.Serie.Commands.UpdateSerie;
using Medical.Application.Features.Serie.Queries.GetSeries;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SerieController : ControllerBase
{
    private readonly IMediator _mediator;

    public SerieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetSeries()
    {
        var response = await _mediator.Send(new GetAllSerieQueryRequest());
        return Ok(response);
    }

    [HttpGet("user")]
    public async Task<ActionResult<IResponse>> GetSeriesByUserId(string user)
    {
        var response = await _mediator.Send(new GetSeriesByUserIdQueryRequest(user));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminSeries()
    {
        var response = await _mediator.Send(new GetAllSerieQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteSerie(int id)
    {
        var result = await _mediator.Send(new DeleteSerieCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SerieDto>>(new List<SerieDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllSerieQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddSerie(SerieDto item)
    {
        await _mediator.Send(new AddSerieCommandRequest(item));

        var response = await _mediator.Send(new GetAllSerieQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateSerie(SerieDto item)
    {
        var result = await _mediator.Send(new UpdateSerieCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SerieDto>>(new List<SerieDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllSerieQueryRequest(true));
        return Ok(response);
    }
}
