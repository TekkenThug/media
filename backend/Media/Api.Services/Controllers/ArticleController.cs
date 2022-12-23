using Api.Data.Article.Operations.GetArticleListItems;
using Api.Services.Article;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Controllers;

public class ArticleController : MediaControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    [Route("feed")]
    public Task<GetArticleListItemsResponse> GetArticleListItems() => _articleService.GetArticleListItems();
}