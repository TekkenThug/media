namespace Api.Services.Article;

public class ArticleController : MediaControllerBase<ArticleService>, IArticleService
{
    public ArticleController(ArticleService service) : base(service)
    {
    }
}