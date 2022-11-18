using Microsoft.EntityFrameworkCore;

namespace Api.Data.Article;

public readonly struct ArticleDbContext : IEntityDbContext<ArticleOrm>
{
    public DbSet<ArticleOrm> Articles { get; }

    public ArticleDbContext(DbContext db)
    {
        this.Articles = db.Set<ArticleOrm>();
    }
    
    public async Task<ArticleOrm> GetModel(int modelId)
    {
        return await GetModels().FirstOrDefaultAsync(x => x.Id == modelId);
    }

    public IQueryable<ArticleOrm> GetModels()
    {
        return Articles.Include(x => x.Author).Include(x => x.Editor);
    }
}