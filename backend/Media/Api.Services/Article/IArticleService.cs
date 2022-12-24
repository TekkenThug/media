using Api.Data.Article;
using Api.Data.Article.Operations.AddArticle;
using Api.Data.Article.Operations.AddArticleToReview;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.HideArticle;
using Api.Data.Article.Operations.PublishArticle;
using Api.Data.Article.Operations.RefuseArticle;
using Api.Data.Article.Operations.UpdateArticle;

namespace Api.Services.Article;

public interface IArticleService : IServiceBase<ArticleOrm>
{
    Task<GetArticleListItemsResponse> GetArticleListItems();
    
    Task<PublishArticleResponse> PublishArticle(PublishArticleRequest request);
    
    Task<AddArticleResponse> AddArticle(AddArticleRequest request);

    Task<RefuseArticleResponse> RefuseArticle(RefuseArticleRequest request);
    
    Task<AddArticleToReviewResponse> AddArticleToReview(AddArticleToReviewRequest request);
    
    Task<HideArticleResponse> HideArticle(HideArticleRequest request);
    
    Task<UpdateArticleResponse> UpdateArticle(UpdateArticleRequest request);
}