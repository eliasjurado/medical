using MediatR;
using Medical.Application.Features.Client.Commands.AddClient;
using Medical.Application.Features.Client.Commands.DeleteClient;
using Medical.Application.Features.Client.Commands.UpdateClient;
using Medical.Application.Features.Client.Queries.GetClients;
using Medical.Domain.Dto.Person;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetClients()
    {
        var response = await _mediator.Send(new GetAllClientQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetClientByFullName(string name)
    {
        var response = await _mediator.Send(new GetClientByFullNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminClients()
    {
        var response = await _mediator.Send(new GetAllClientQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteClient(int id)
    {
        var result = await _mediator.Send(new DeleteClientCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ClientDto>>(new List<ClientDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllClientQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddClient(ClientDto item)
    {
        await _mediator.Send(new AddClientCommandRequest(item));

        var response = await _mediator.Send(new GetAllClientQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateClient(ClientDto item)
    {
        var result = await _mediator.Send(new UpdateClientCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ClientDto>>(new List<ClientDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllClientQueryRequest(true));
        return Ok(response);
    }
}
