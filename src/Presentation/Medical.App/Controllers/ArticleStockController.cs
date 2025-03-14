using MediatR;
using Medical.Application.Features.ArticleStock.Commands.AddArticleStock;
using Medical.Application.Features.ArticleStock.Commands.DeleteArticleStock;
using Medical.Application.Features.ArticleStock.Commands.UpdateArticleStock;
using Medical.Application.Features.ArticleStock.Queries.GetArticleStocks;
using Medical.Domain.Dto.Sales;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Medical.Application.Features.ArticleStock.Queries.GetArticleStock;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleStockController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleStockController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetArticleStocks()
    {
        var response = await _mediator.Send(new GetAllArticleStockQueryRequest());
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminArticleStocks()
    {
        var response = await _mediator.Send(new GetAllArticleStockQueryRequest(true));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IResponse>> GetStockByArticleId(int id)
    {
        var response = await _mediator.Send(new GetStockByArticleIdQueryRequest(id));
        return Ok(response);
    }    

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteArticleStock(int id)
    {
        var result = await _mediator.Send(new DeleteArticleStockCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ArticleStockDto>>(new List<ArticleStockDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllArticleStockQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddArticleStock(ArticleStockDto item)
    {
        await _mediator.Send(new AddArticleStockCommandRequest(item));

        var response = await _mediator.Send(new GetAllArticleStockQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateArticleStock(ArticleStockDto item)
    {
        var result = await _mediator.Send(new UpdateArticleStockCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ArticleStockDto>>(new List<ArticleStockDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllArticleStockQueryRequest(true));
        return Ok(response);
    }
}
