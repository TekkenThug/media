using Api.Data.Article;
using Api.Data.Article.Operations.AddArticle;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.PublishArticle;

namespace Api.Services.Article;

public interface IArticleService : IServiceBase<ArticleOrm>
{
    Task<GetArticleListItemsResponse> GetArticleListItems();
    
    Task<PublishArticleResponse> PublishArticle(PublishArticleRequest request);
    
    Task<AddArticleResponse> AddArticle(AddArticleRequest request);
}