using MediatR;
using Medical.Application.Features.AppUser.Commands.AddAppUser;
using Medical.Application.Features.AppUser.Commands.UpdateAppUser;
using Medical.Application.Features.AppUser.Queries.GetAppUsers;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetAppUsers()
    {
        var response = await _mediator.Send(new GetAllAppUserQueryRequest());
        return Ok(response);
    }

    [HttpGet("user")]
    public async Task<ActionResult<IResponse>> GetAppUserByUserId(string user)
    {
        var response = await _mediator.Send(new GetAppUserByUserIdQueryRequest(user));
        return Ok(response);
    }

    [HttpGet("email")]
    public async Task<ActionResult<IResponse>> GetAppUserByEmail(string email)
    {
        var response = await _mediator.Send(new GetAppUserByEmailQueryRequest(email));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminAppUsers()
    {
        var response = await _mediator.Send(new GetAllAppUserQueryRequest(true));
        return Ok(response);
    }

    //[HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    //public async Task<ActionResult<IResponse>> DeleteAppUser(int id)
    //{
    //    var result = await _mediator.Send(new DeleteAppUserCommandRequest(id));

    //    if (!result.Success)
    //    {
    //        var responseCast = (DataResponse<string>)result;

    //        return new DataResponse<List<AppUserDto>>(new List<AppUserDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
    //    }

    //    var response = await _mediator.Send(new GetAllAppUserQueryRequest(true));
    //    return Ok(response);
    //}

    [HttpPost("admin")]//, Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddAppUser(AppUserDto item)
    {
        await _mediator.Send(new AddAppUserCommandRequest(item));

        var response = await _mediator.Send(new GetAllAppUserQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin")]//, Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateAppUser(AppUserDto item)
    {
        var result = await _mediator.Send(new UpdateAppUserCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<AppUserDto>>(new List<AppUserDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllAppUserQueryRequest(true));
        return Ok(response);
    }
}
