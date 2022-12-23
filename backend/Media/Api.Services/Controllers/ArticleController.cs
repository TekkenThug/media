using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.PublishArticle;
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
    
    [HttpPost]
    [Route("publish")]
    public Task<PublishArticleResponse> PublishArticle(PublishArticleRequest request) => _articleService.PublishArticle(request);
}