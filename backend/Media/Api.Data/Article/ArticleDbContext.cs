using Microsoft.EntityFrameworkCore;

namespace Api.Data.Article;

public readonly struct ArticleDbContext : IEntityDbContext<ArticleOrm>
{
    public DbSet<ArticleOrm> Articles { get; }

    public ArticleDbContext(DbContext db)
    {
        this.Articles = db.Set<ArticleOrm>();
    }
    
    public ArticleOrm GetModel(int modelId)
    {
        return GetModels().FirstOrDefault(x => x.Id == modelId);
    }

    public IQueryable<ArticleOrm> GetModels()
    {
        return Articles.Include(x => x.Author).Include(x => x.Editor);
    }
}