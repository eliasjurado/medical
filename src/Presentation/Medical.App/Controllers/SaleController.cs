using MediatR;
using Medical.Application.Features.Sale.Commands.AddSale;
using Medical.Application.Features.Sale.Queries.GetSales;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetSales()
    {
        var response = await _mediator.Send(new GetAllSaleQueryRequest());
        return Ok(response);
    }

    //[HttpGet("name")]
    //public async Task<ActionResult<IResponse>> GetSaleByName(string name)
    //{
    //    var response = await _mediator.Send(new GetSaleByNameQueryRequest(name));
    //    return Ok(response);
    //}

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminSales()
    {
        var response = await _mediator.Send(new GetAllSaleQueryRequest(true));
        return Ok(response);
    }

    //[HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    //public async Task<ActionResult<IResponse>> DeleteSale(int id)
    //{
    //    var result = await _mediator.Send(new DeleteSaleCommandRequest(id));

    //    if (!result.Success)
    //    {
    //        var responseCast = (DataResponse<string>)result;

    //        return new DataResponse<List<SaleDto>>(new List<SaleDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
    //    }

    //    var response = await _mediator.Send(new GetAllSaleQueryRequest(true));
    //    return Ok(response);
    //}

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddSale(SaleDto item)
    {
        var r = await _mediator.Send(new AddSaleCommandRequest(item));

        var response = await _mediator.Send(new GetAllSaleQueryRequest(true));
        return Ok(response);
    }

    //[HttpPut("admin"), Authorize(Roles = "Administrador")]
    //public async Task<ActionResult<IResponse>> UpdateSale(SaleDto item)
    //{
    //    var result = await _mediator.Send(new UpdateSaleCommandRequest(item));

    //    if (!result.Success)
    //    {
    //        var responseCast = (DataResponse<string>)result;

    //        return new DataResponse<List<SaleDto>>(new List<SaleDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
    //    }

    //    var response = await _mediator.Send(new GetAllSaleQueryRequest(true));
    //    return Ok(response);
    //}
}
