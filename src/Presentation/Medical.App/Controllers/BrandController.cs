using MediatR;
using Medical.Application.Features.Brand.Commands.AddBrand;
using Medical.Application.Features.Brand.Commands.DeleteBrand;
using Medical.Application.Features.Brand.Commands.UpdateBrand;
using Medical.Application.Features.Brand.Queries.GetBrands;
using Medical.Domain.Dto.Brand;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetBrands()
    {
        var response = await _mediator.Send(new GetAllBrandQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminBrands()
    {
        var response = await _mediator.Send(new GetAllBrandQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteBrand(int id)
    {
        var result = await _mediator.Send(new DeleteBrandCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<BrandDto>>(new List<BrandDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllBrandQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddBrand(BrandDto item)
    {
        await _mediator.Send(new AddBrandCommandRequest(item));

        var response = await _mediator.Send(new GetAllBrandQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateBrand(BrandDto item)
    {
        var result = await _mediator.Send(new UpdateBrandCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<BrandDto>>(new List<BrandDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllBrandQueryRequest(true));
        return Ok(response);
    }
}
