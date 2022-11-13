using Api.Data;
using Api.Data.Article;

namespace Api.Services.Article;

public class ArticleService  : DbServiceEntityBase<ArticleOrm, ArticleDbContext>, IArticleService
{
    public ArticleService(MediaDbContext context) : base(context)
    {
    }

    protected override ArticleDbContext CreateDbContext()
    {
        return new ArticleDbContext(this.Context);
    }
}