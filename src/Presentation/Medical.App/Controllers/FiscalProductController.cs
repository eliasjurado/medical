using MediatR;
using Medical.Application.Features.FiscalProduct.Commands.AddFiscalProduct;
using Medical.Application.Features.FiscalProduct.Commands.DeleteFiscalProduct;
using Medical.Application.Features.FiscalProduct.Commands.UpdateFiscalProduct;
using Medical.Application.Features.FiscalProduct.Queries.GetFiscalProducts;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetFiscalProducts()
    {
        var response = await _mediator.Send(new GetAllFiscalProductQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetFiscalProductByName(string name)
    {
        var response = await _mediator.Send(new GetFiscalProductByNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminFiscalProducts()
    {
        var response = await _mediator.Send(new GetAllFiscalProductQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteFiscalProduct(int id)
    {
        var result = await _mediator.Send(new DeleteFiscalProductCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalProductDto>>(new List<FiscalProductDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalProductQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddFiscalProduct(FiscalProductDto item)
    {
        await _mediator.Send(new AddFiscalProductCommandRequest(item));

        var response = await _mediator.Send(new GetAllFiscalProductQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateFiscalProduct(FiscalProductDto item)
    {
        var result = await _mediator.Send(new UpdateFiscalProductCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<FiscalProductDto>>(new List<FiscalProductDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllFiscalProductQueryRequest(true));
        return Ok(response);
    }
}
