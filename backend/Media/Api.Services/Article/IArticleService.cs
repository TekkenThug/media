using Api.Data.Article;
using Api.Data.Article.Operations.GetArticleListItems;

namespace Api.Services.Article;

public interface IArticleService : IServiceBase<ArticleOrm>
{
    Task<GetArticleListItemsResponse> GetArticleListItems();
}