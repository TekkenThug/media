namespace Api.Services.Article;

public class ArticleController : MediaControllerBase<IArticleService>, IArticleService
{
    public ArticleController(IArticleService service) : base(service)
    {
    }
}