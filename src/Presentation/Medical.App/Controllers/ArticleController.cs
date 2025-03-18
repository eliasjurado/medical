using MediatR;
using Medical.Application.Features.Article.Commands.AddArticle;
using Medical.Application.Features.Article.Commands.DeleteArticle;
using Medical.Application.Features.Article.Commands.UpdateArticle;
using Medical.Application.Features.Article.Queries.GetArticles;
using Medical.Domain.Dto.Response.Abstract;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IResponse>> GetArticles()
    {
        var response = await _mediator.Send(new GetAllArticleQueryRequest());
        return Ok(response);
    }

    [HttpGet("name")]
    public async Task<ActionResult<IResponse>> GetArticleByName(string name)
    {
        var response = await _mediator.Send(new GetArticleByNameQueryRequest(name));
        return Ok(response);
    }

    [HttpGet("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> GetAdminArticles()
    {
        var response = await _mediator.Send(new GetAllArticleQueryRequest(true));
        return Ok(response);
    }

    [HttpDelete("admin/{id}"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> DeleteArticle(int id)
    {
        var result = await _mediator.Send(new DeleteArticleCommandRequest(id));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ArticleDto>>(new List<ArticleDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllArticleQueryRequest(true));
        return Ok(response);
    }

    [HttpPost("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> AddArticle(ArticleDto item)
    {
        await _mediator.Send(new AddArticleCommandRequest(item));

        var response = await _mediator.Send(new GetAllArticleQueryRequest(true));
        return Ok(response);
    }

    [HttpPut("admin"), Authorize(Roles = "Administrador")]
    public async Task<ActionResult<IResponse>> UpdateArticle(ArticleDto item)
    {
        var result = await _mediator.Send(new UpdateArticleCommandRequest(item));

        if (!result.Success)
        {
            var responseCast = (DataResponse<string>)result;

            return new DataResponse<List<ArticleDto>>(new List<ArticleDto>(), responseCast.StatusCode, responseCast.Messages.FirstOrDefault()!);
        }

        var response = await _mediator.Send(new GetAllArticleQueryRequest(true));
        return Ok(response);
    }
}
