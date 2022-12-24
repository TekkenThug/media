using Api.Data.Article.Operations.AddArticle;
using Api.Data.Article.Operations.AddArticleToReview;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.HideArticle;
using Api.Data.Article.Operations.PublishArticle;
using Api.Data.Article.Operations.RefuseArticle;
using Api.Data.Article.Operations.UpdateArticle;
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
    [Route("add")]
    public Task<AddArticleResponse> AddArticle(AddArticleRequest request) => _articleService.AddArticle(request);
    
    [HttpPost]
    [Route("review")]
    public Task<AddArticleToReviewResponse> AddArticleToReview(AddArticleToReviewRequest request) => _articleService.AddArticleToReview(request);
    
    [HttpPost]
    [Route("refuse")]
    public Task<RefuseArticleResponse> RefuseArticle(RefuseArticleRequest request) => _articleService.RefuseArticle(request);

    [HttpPost]
    [Route("publish")]
    public Task<PublishArticleResponse> PublishArticle(PublishArticleRequest request) => _articleService.PublishArticle(request);
    
    [HttpPost]
    [Route("hide")]
    public Task<HideArticleResponse> HideArticle(HideArticleRequest request) => _articleService.HideArticle(request);
    
    [HttpPost]
    [Route("update")]
    public Task<UpdateArticleResponse> UpdateArticle(UpdateArticleRequest request) => _articleService.UpdateArticle(request);
}