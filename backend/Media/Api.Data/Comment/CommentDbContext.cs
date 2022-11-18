using Microsoft.EntityFrameworkCore;

namespace Api.Data.Comment;

public readonly struct CommentDbContext : IEntityDbContext<CommentOrm>
{
    public DbSet<CommentOrm> Comments { get; }

    public CommentDbContext(DbContext db)
    {
        this.Comments = db.Set<CommentOrm>();
    }
    
    public async Task<CommentOrm> GetModel(int modelId)
    {
        return await GetModels().FirstOrDefaultAsync(x => x.Id == modelId);
    }

    public IQueryable<CommentOrm> GetModels()
    {
        return Comments
            .Include(x => x.Article)
            .Include(x => x.Author)
            .Include(x => x.Author);
    }
}