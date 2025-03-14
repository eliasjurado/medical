using MediatR;
using Medical.Application.Features.Warehouse.Commands.AddWarehouse;
using Medical.Application.Features.Warehouse.Commands.DeleteWarehouse;
using Medical.Application.Features.Warehouse.Commands.UpdateWarehouse;
using Medical.Application.Features.Warehouse.Queries.GetWarehouses;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IMediator _mediator;

    public WarehouseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetWarehouses()
    {
        var response = await _mediator.Send(new GetAllWarehouseQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetWarehouseByName(string name)
    {
        var response = await _mediator.Send(new GetWarehouseByNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminWarehouses()
    {
        var response = await _mediator.Send(new GetAllWarehouseQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteWarehouse(int id)
    {
        var result = await _mediator.Send(new DeleteWarehouseCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<WarehouseDto>>(new List<WarehouseDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllWarehouseQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddWarehouse(WarehouseDto item)
    {
        await _mediator.Send(new AddWarehouseCommandRequest(item));

        var response = await _mediator.Send(new GetAllWarehouseQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateWarehouse(WarehouseDto item)
    {
        var result = await _mediator.Send(new UpdateWarehouseCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<WarehouseDto>>(new List<WarehouseDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllWarehouseQueryRequest(true));
        return Ok(response);
    }
}
