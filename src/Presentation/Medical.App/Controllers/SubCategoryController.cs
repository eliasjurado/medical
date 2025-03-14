using Medical.Application.Features.SubCategory.Commands.AddSubCategory;
using Medical.Application.Features.SubCategory.Commands.DeleteSubCategory;
using Medical.Application.Features.SubCategory.Commands.UpdateSubCategory;
using Medical.Application.Features.SubCategory.Queries.GetSubCategories;
using Medical.Domain.Dto.Response.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Sales;
using Medical.Application.Features.FiscalUnit.Queries.GetFiscalUnits;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetSubCategories()
    {
        var response = await _mediator.Send(new GetAllSubCategoryQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetSubCategoryByName(string name)
    {
        var response = await _mediator.Send(new GetSubCategoryByNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminSubCategories()
    {
        var response = await _mediator.Send(new GetAllSubCategoryQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteSubCategory(int id)
    {
        var result = await _mediator.Send(new DeleteSubCategoryCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SubCategoryDto>> (new List<SubCategoryDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllSubCategoryQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddSubCategory(SubCategoryDto SubCategory)
    {
        await _mediator.Send(new AddSubCategoryCommandRequest(SubCategory));

        var response = await _mediator.Send(new GetAllSubCategoryQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateSubCategory(SubCategoryDto SubCategory)
    {
        var result = await _mediator.Send(new UpdateSubCategoryCommandRequest(SubCategory));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<SubCategoryDto>>(new List<SubCategoryDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllSubCategoryQueryRequest(true));
        return Ok(response);
    }
}
