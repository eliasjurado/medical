using Medical.Application.Features.Appointment.Commands.AddAppointment;
using Medical.Application.Features.Appointment.Commands.DeleteAppointment;
using Medical.Application.Features.Appointment.Commands.UpdateAppointment;
using Medical.Application.Features.Appointment.Queries.GetAppointments;
using Medical.Domain.Dto.Appointment;
using Medical.Domain.Dto.Response.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Medical.Domain.Dto.Response.Abstract;
using System.Text.Json;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetAppointments()
    {
        var response = await _mediator.Send(new GetAllAppointmentQueryRequest());
        return Ok(response);// Ok(JsonSerializer.Serialize(response,options: new JsonSerializerOptions { ReferenceHandler=System.Text.Json.Serialization.ReferenceHandler.Preserve}));
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminAppointments()
    {
        var response = await _mediator.Send(new GetAllAppointmentQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteAppointment(int id)
    {
        var result = await _mediator.Send(new DeleteAppointmentCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<AppointmentDto>>(new List<AppointmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllAppointmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin")]//, Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddAppointment(AppointmentDto appointment)
    {
        await _mediator.Send(new AddAppointmentCommandRequest(appointment));

        var response = await _mediator.Send(new GetAllAppointmentQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateAppointment(AppointmentDto appointment)
    {
        var result = await _mediator.Send(new UpdateAppointmentCommandRequest(appointment));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<AppointmentDto>>(new List<AppointmentDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllAppointmentQueryRequest(true));
        return Ok(response);
    }
}
