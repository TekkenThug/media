using Api.Db;

namespace Api.Services.Article;

public class ArticleService : MediaServiceBase, IArticleService
{
    public ArticleService(ApplicationContext context) : base(context)
    {
    }
}